using BookStoreApp.Models;
using BookStoreApp.Models.DTOs;

namespace BookStoreApp.Interface
{
    public interface IBookService
    {
        List<Books> GetBooks(string search);
        BookDTO AddBook(BookDTO bookDTO);
        BookDTO UpdateBook(int id, BookDTO bookDTO);

        List<Books> GetByUserId(string id);
        bool RemoveBook(int id);
    }
}
