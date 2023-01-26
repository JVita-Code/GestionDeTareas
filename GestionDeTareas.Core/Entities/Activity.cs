using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestionDeTareas.API.Entities;

public class Activity : EntityBase
{
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
    [Required]
    [DefaultValue(false)]
    public bool IsCompleted { get; set; }
    public DateTime? CompletedAt { get; set; }

    [Required]
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }

    //[JsonIgnore]
    public Category Category { get; set; }
    
}
