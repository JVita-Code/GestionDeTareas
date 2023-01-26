using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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
