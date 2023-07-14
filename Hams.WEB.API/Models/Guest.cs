using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Hams.WEB.API.Models
{
    public class Guest
    {
        [Required]
        public int? ID { get; set; }
        [Required]
        public string? Names { get; set; }
        [Required]
        public string? LastNames { get; set; }
        public string? PhoneNumber { get; set; }
        [Required]
        public string? UserID { get; set; }
        public IdentityUser? User { get; set; }
    }
}
