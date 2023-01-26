using System.ComponentModel.DataAnnotations;

namespace GestionDeTareas.API.Core.Models.DTOs.Activity
{
    public class UpdateActivityDto : BaseDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CompletedAt { get; set; }
        public int CategoryId { get; set; }
    }
}
