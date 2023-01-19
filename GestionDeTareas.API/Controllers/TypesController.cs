using GestionDeTareas.API.Core.Interfaces;
using GestionDeTareas.API.Core.Models;
using GestionDeTareas.API.Core.Models.DTOs.Category;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeTareas.API.Controllers
{
    //[Route("api/[controller]")]
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesBusiness _categoriesService;

        public CategoriesController(ICategoriesBusiness categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoriesService.GetCategoriesAsync(true);

            if (!result.Succeeded)
            {
                if (result.Errors.Count > 0)
                {
                    return StatusCode(500, result);
                }

                return StatusCode(400, result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoriesService.GetCategoryAsync(id);

            if (result.Succeeded == false)
            {
                if (result.Errors.Count > 0)
                {
                    return StatusCode(500, result);
                }

                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromForm] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await _categoriesService.InsertCategoryAsync(categoryDto);

            if (response.Succeeded)
            {
                return Created(Url.Action(nameof(Create)), response);
            }
            else
            {
                if (response.Errors.Count > 0)
                {
                    return StatusCode(500, response);
                }

                return BadRequest(response);
            }
        }

        [HttpPatch]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromForm] CategoryDto data, int id)
        {
            if (data.Name == null && data.Description == null)
            {
                return BadRequest(new Response<string>(null, false, null, "Please select at least one field to modify."));
            }

            var result = await _categoriesService.UpdateCategoryAsync(data, id);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                if (result.Errors.Count > 0)
                {
                    return StatusCode(500, result);
                }

                return BadRequest(result);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoriesService.DeleteAsync(id);

            if (!result.Succeeded)
            {
                if (result.Errors.Count > 0)
                {
                    return StatusCode(500, result);
                }

                return StatusCode(statusCode: 404, result);
            }

            return Ok(result);
        }
    }
}
