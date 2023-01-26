using GestionDeTareas.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionDeTareas.API.DataAccess.SeedsData
{
    public class SeedCategories : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            for (int i = 1; i < 11; i++)
            {
                builder.HasData(
                    new Entities.Category
                         {
                             Id = i,
                             Name = "Category " + i,
                             Description = "description of category " + i,
                             ModifiedAt = System.DateTime.Now,
                             IsDeleted = false
                         }
                );
            }
        }
    }
}
