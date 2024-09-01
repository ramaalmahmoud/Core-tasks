using System.ComponentModel.DataAnnotations;

namespace _1_9_2024.Models
{
    public class UserDTO
    {
       
        public string UserName { get; set; }
        
        public string? Email { get; set; }
       
        public string Password { get; set; }
    }
}
