using GestionDeTareas.API.Core.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionDeTareas.API.Controllers
{
    [ApiController]
    [Route("auths")]
    public class AuthsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public AuthsController(UserManager<IdentityUser> userManager, IConfiguration configuration,
                                SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ResponseAuth>> Register(UserCredentials userCredentials)
        {
            var user = new IdentityUser { UserName = userCredentials.Email, Email = userCredentials.Email};
            var result = await userManager.CreateAsync(user, userCredentials.Password );

            if (result.Succeeded)
            {
                return CreateToken(userCredentials);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseAuth>> Login(UserCredentials userCredentials)
        {
            var result = await signInManager.PasswordSignInAsync(userCredentials.Email,
                                                                userCredentials.Password, isPersistent: false, 
                                                                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return CreateToken(userCredentials);
            }
            else
            {
                return BadRequest("Login failled");
            }
        }

        private ResponseAuth CreateToken(UserCredentials userCredentials)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", userCredentials.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["KeyJwt"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(1);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, 
                                                                  claims: claims, expires : expiration, 
                                                                  signingCredentials: creds);

            return new ResponseAuth()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiration = expiration
            };


        }
    }
}
