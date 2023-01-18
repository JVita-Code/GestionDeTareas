using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestionDeTareas.API.Core.Models.DTOs.Activity
{
    public class InsertActivityDto : BaseDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; }

        [DefaultValue(false)]
        public bool IsCompleted { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CompletedAt { get; set; } = DateTime.Now;
    }
}