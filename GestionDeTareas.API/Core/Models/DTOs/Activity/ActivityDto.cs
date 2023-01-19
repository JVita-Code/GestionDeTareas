using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestionDeTareas.API.Core.Models.DTOs.Activity
{
    public class ActivityDto : BaseDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [DefaultValue(false)]
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
