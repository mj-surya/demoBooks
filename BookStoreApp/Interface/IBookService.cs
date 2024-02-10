using BookStoreApp.Models;
using BookStoreApp.Models.DTOs;

namespace BookStoreApp.Interface
{
    public interface IBookService
    {
        List<Books> GetBooks(string search,string genre);
        BookDTO AddBook(BookDTO bookDTO);
        Books UpdateBook(int id, Books books);
        Books GetById(int id);
        List<Books> GetByUserId(string id);
        bool RemoveBook(int id);
    }
}
