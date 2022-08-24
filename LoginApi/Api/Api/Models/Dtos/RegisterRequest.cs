namespace Api.Models.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterRequest
    {
        
      
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Roles { get; set; }
    }
}
