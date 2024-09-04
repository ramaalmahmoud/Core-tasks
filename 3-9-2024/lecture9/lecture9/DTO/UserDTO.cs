using System.ComponentModel.DataAnnotations;

namespace lecture9.DTO
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
