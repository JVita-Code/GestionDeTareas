using Microsoft.EntityFrameworkCore;

namespace GestionDeTareas.API.DataAccess
{
    public class GestorContext : DbContext
    {
        readonly ModelBuilder _modelBuilder;

        public GestorContext(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public GestorContext(DbContextOptions<GestorContext> options)
            : base(options) 
        { }

        //public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
