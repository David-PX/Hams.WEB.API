using System.ComponentModel.DataAnnotations;

namespace Hams.WEB.API.DTOs
{
    public class ResetPasswordDTO
    {
        [Required]
        public int? UserId { get; set; }

        [Required(ErrorMessage = "The old password  is required")]
        public string? oldPassword { get; set; }

        [Required(ErrorMessage = "The new password  is required")]
        public string? newPassword { get; set; }

        [Required(ErrorMessage = "The confirmpassword  is required")]
        [Compare("newPassword", ErrorMessage = "The passwords fields do not match.")]
        public string confirmPassword { get; set; }
    }
}
