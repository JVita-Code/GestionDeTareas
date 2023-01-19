using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace GestionDeTareas.API.Entities
{
    public class Comment : EntityBase
    {
        [MaxLength(65535)]
        public string Body { get; set; }

        public int ActivityId { get; set; }

        //[JsonIgnore]
        public Activity Activity { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
