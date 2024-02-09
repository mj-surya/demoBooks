using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models.DTOs
{
    public class BookDTO
    {
        [Required(ErrorMessage = "Title cannot be empty")]
        public string Title { get; set; } = "";
        [Required(ErrorMessage = "UserId cannot be empty")]
        public string UserId { get; set; } = "";
        [Required(ErrorMessage = "Author cannot be empty")]
        public string Author { get; set; } = "";
        [Required(ErrorMessage = "Genre cannot be empty")]
        public string Genre { get; set; } = "";
        [Required(ErrorMessage = "Publish Date cannot be empty")]
        public string PublishDate { get; set; } = "";
        [Required(ErrorMessage = "Price cannot be empty")]
        public float Price { get; set; } = 0;
        [Required(ErrorMessage = "Image is Mandatory")]
        public IFormFile? Image { get; set; }
    }
}
