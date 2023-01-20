using GestionDeTareas.API.Core.Business;
using GestionDeTareas.API.Core.Interfaces;
using GestionDeTareas.API.Core.Mapper;
using GestionDeTareas.API.DataAccess;
using GestionDeTareas.API.Repositories.Interfaces;
using GestionDeTareas.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;

namespace GestionDeTareas.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GestorContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Repos
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddTransient<IEntityMapper, EntityMapper>();

            //Business-Services
            services.AddScoped<IActivitiesBusiness, ActivitiesBusiness>();
            services.AddScoped<ICategoriesBusiness, CategoriesBusiness>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<GestorContext>()
                    .AddDefaultTokenProviders();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Gestor de Tareas",
                    Version = "v1",
                    Description = "API Rest - Actividades y Categorias",
                    Contact = new OpenApiContact
                    {
                        Email = "juanvitan@gmail.com",
                        Name = "Juan Vitale"
                    },
                });
                
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                }); 
                
                var archivoXml = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var rutaXml = Path.Combine(AppContext.BaseDirectory, archivoXml);
                c.IncludeXmlComments(rutaXml);
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["KeyJwt"])),
                    ClockSkew = TimeSpan.Zero
                });

            //services.AddCors(o =>
            //{
            //    o.AddDefaultPolicy(builder =>
            //    {
            //        builder.WithOrigins("https://www.apirequest.io").AllowAnyMethod().AllowAnyHeader().WithExposedHeaders();
            //    });
            //});

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("./v1/swagger.json", "Gestor Project v1");
                    //c.RoutePrefix = "api/docs";
                    
                });
            }

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
