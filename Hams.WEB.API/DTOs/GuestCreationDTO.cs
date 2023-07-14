using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Hams.WEB.API.DTOs
{
    public class GuestCreationDTO
    {
        [Required]
        public int? ID { get; set; }
        [Required]
        public string? Names { get; set; }
        [Required]
        public string? LastNames { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
      
    }
}
