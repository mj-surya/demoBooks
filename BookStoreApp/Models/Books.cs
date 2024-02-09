using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    public class Books
    {
        [Key]
        public int BookID{ get; set; } = 0;
        public string UserId { get; set; } = "";
        [ForeignKey("UserId")]
        public User user { get; set; }
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string Genre { get; set; } = "";
        public string PublishDate { get; set; } = "";
        public string Image { get; set; } = "";
        public float Price { get; set; } = 0;
    }
}
