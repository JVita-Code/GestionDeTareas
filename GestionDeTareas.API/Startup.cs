using GestionDeTareas.API.Core.Business;
using GestionDeTareas.API.Core.Interfaces;
using GestionDeTareas.API.Core.Mapper;
using GestionDeTareas.API.DataAccess;
using GestionDeTareas.API.Repositories.Interfaces;
using GestionDeTareas.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace GestionDeTareas.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
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
            services.AddTransient<IEntityMapper, EntityMapper>();

            //Business-Services
            services.AddScoped<IActivitiesBusiness, ActivitiesBusiness>();

            services.AddControllers();            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("swagger/v1/swagger.json", "Gestor Project v1");
                    c.RoutePrefix = "api/docs";
                });
            }            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
