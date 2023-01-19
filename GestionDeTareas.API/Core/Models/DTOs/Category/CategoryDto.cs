using System.ComponentModel.DataAnnotations;

namespace GestionDeTareas.API.Core.Models.DTOs.Category;

public class CategoryDto : BaseDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(255)]
    public string Name { get; set; }
    [MaxLength(255)]
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }
}
