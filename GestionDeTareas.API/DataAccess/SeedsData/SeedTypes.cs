using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionDeTareas.API.DataAccess.SeedsData
{
    public class SeedTypes : IEntityTypeConfiguration<Type>
    {
        public void Configure(EntityTypeBuilder<Type> builder)
        {
            for (int i = 1; i < 11; i++)
            {
                builder.HasData(
                    new Entities.Type
                    {
                        Id = i,
                        Name = "Type " + i,
                        Description = "description of type " + i,
                        ModifiedAt = System.DateTime.Now,
                        IsDeleted = false
                    }
                );
            }
        }
    }
}
