namespace GestionDeTareas.API.Core.Models.DTOs
{
    public class ResponseAuth
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
