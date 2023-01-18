using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GestionDeTareas.API.Core.Models.DTOs
{
    public class BaseDto
    {
        //[Key]
        //public int? Id { get; set; }
        //[Required]
        public DateTime? ModifiedAt { get; set; } = DateTime.Now;
        //[Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
