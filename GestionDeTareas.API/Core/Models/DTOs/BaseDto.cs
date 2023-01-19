using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GestionDeTareas.API.Core.Models.DTOs
{
    public class BaseDto
    {
        public DateTime? ModifiedAt { get; set; } = DateTime.UtcNow;
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
