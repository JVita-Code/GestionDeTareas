using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestionDeTareas.API.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime? ModifiedAt { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; } 
        public DateTime? DeletedAt { get; set; }
    }
}
