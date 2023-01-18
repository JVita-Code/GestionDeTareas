using GestionDeTareas.API.DataAccess.SeedsData;
using GestionDeTareas.API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestionDeTareas.API.DataAccess
{
    public class GestorContext : IdentityDbContext
    {
        readonly ModelBuilder _modelBuilder;

        public GestorContext(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public GestorContext(DbContextOptions<GestorContext> options)
            : base(options) 
        { }

        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SeedActivities());
        }
    }
}
