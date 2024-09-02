using System.ComponentModel.DataAnnotations;

namespace _2_9_2024.Models
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string repeatePassword { get; set; }
    }
}
