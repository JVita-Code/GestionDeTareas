using System.ComponentModel.DataAnnotations;

namespace GestionDeTareas.API.Core.Models.DTOs.Activity
{
    public class ActivityDto : BaseDto
    {
        //public int? Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
