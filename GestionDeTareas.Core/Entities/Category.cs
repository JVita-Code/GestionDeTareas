using System.ComponentModel.DataAnnotations;

namespace GestionDeTareas.API.Entities
{
    public class Category : EntityBase
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        [Required]
        public string Description { get; set; }

        public List<Activity> Activities { get; set; }
    }
}
