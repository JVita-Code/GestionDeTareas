using GestionDeTareas.API.Entities;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GestionDeTareas.API.Core.Models.DTOs.Category;

public class CategoryDto : BaseDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(255)]
    public string Name { get; set; }
    [MaxLength(255)]
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }
    public List<Entities.Activity> Activities { get; set; }
}
