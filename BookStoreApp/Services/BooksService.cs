using BookStoreApp.Interface;
using BookStoreApp.Models;
using BookStoreApp.Exceptions;
using BookStoreApp.Models.DTOs;
using HotelBookingApplication.Exceptions;
using BookStoreApp.Repository;

namespace BookStoreApp.Services
{
    public class BooksService: IBookService
    {
        private readonly IRepository<int, Books> _booksRepository;
        public BooksService(IRepository<int, Books> repository) {
            _booksRepository = repository;
        }

        public BookDTO AddBook(BookDTO bookDTO)
        {
            Books check;
            try
            {
                check = _booksRepository.GetAll().FirstOrDefault(u => u.Title == bookDTO.Title);
            }
            catch (Exception)
            {
                check = null;
            }
            if(check == null)
            {
                Books books = new Books()
                {
                    Title = bookDTO.Title,
                    Author = bookDTO.Author,
                    Genre = bookDTO.Genre,
                    PublishDate = bookDTO.PublishDate,
                    UserId = bookDTO.UserId,
                    Price= bookDTO.Price,
                    Image= "http://localhost:5103/Images/"+bookDTO.Image
                };
                var result = _booksRepository.Add(books);
                if (result != null)
                {
                    return bookDTO;
                }
                return null;
            }
            else
            {
                throw new AlreadyAvailableException();
            }
        }

        public List<Books> GetBooks(string search)
        {
            try
            {
                var books = _booksRepository.GetAll().Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
                if (books != null)
                {
                    return books;
                }
            }
            catch (Exception)
            {
                throw new NoBooksAvailableException();
            }
            return null;
        }

        public List<Books> GetByUserId(string id)
        {
            try
            {
                var books = _booksRepository.GetAll().Where(c => c.UserId == id).ToList();
                if (books != null)
                {
                    return books;
                }
            }
            catch (Exception)
            {
                throw new NoBooksAvailableException();
            }
            return null;
        }

        public bool RemoveBook(int id)
        {
            var result = _booksRepository.Delete(id);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public BookDTO UpdateBook(int id, BookDTO bookDTO)
        {
            var book = _booksRepository.GetById(id);

            if (book != null)
            {
                book.Title = bookDTO.Title;
                book.Author = bookDTO.Author;
                book.Genre = bookDTO.Genre;
                book.Price = bookDTO.Price;
                book.PublishDate = bookDTO.PublishDate;
                var result = _booksRepository.Update(book);
                return bookDTO;
            }
            return null;
        }
    }
}
