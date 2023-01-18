using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GestionDeTareas.API.Entities
{
    public class Activity : EntityBase
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }

        //public int CategoryId { get; set; }
        //public virtual Category Category { get; set; }
    }
}
