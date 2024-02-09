using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models
{
    public class User
    {
        [Key]
        public string Email { get; set; } = "";
        public byte[] Password { get; set; } = new byte[32];
        public string Name { get; set; } = "";
        public string Phone { get; set; } = "";    
        public string Role { get; set; } = "";
        public byte[] Key { get; set; } = new byte[32];
    }
}
