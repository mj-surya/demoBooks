using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Contexts
{
    public class BooksContext:DbContext
    {
        public BooksContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Books> Books { get; set; }

    }
}