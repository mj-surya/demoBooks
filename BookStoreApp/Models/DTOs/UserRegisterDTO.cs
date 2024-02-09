using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models.DTOs
{
    public class UserRegisterDTO : UserDTO
    {
        [Required(ErrorMessage = "Re type password cannot be empty")]
        [Compare("Password", ErrorMessage = "Password and retype password do not match")]
        public string ReTypePassword { get; set; } = "";
        [Required(ErrorMessage = "Phone cannot be empty")]
        public string Phone { get; set; } = "";
    }
}
