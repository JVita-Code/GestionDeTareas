using GestionDeTareas.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionDeTareas.API.DataAccess.SeedsData
{
    public class SeedActivities : IEntityTypeConfiguration<Activity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Activity> builder)
        {
            Random rand = new Random();

            for (int i = 1; i < 10; i++)
            {
                builder.HasData(
                    new Activity
                         {
                            Id = i,
                            Title = "Actividad  " + i,
                            Description = "Descripcion de la actividad Número " + i,
                            ModifiedAt = System.DateTime.Now,
                            IsDeleted = false,
                            CategoryId = rand.Next(1,11),
                         }
                );
            }
        }
    }
}
