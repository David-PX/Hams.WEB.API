using System.ComponentModel.DataAnnotations;

namespace Hams.WEB.API.Models.Authentication.SignUp
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Names are required")]
        public string? Names { get; set; }
        [Required(ErrorMessage = "Names are required")]
        public string? LastNames { get; set; }
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
