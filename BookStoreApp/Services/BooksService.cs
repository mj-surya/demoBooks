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
                    Image= "http://localhost:5103/Images/"+bookDTO.Image.FileName
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

        public List<Books> GetBooks(string search,string genre)
        {
            try
            {
                var books=_booksRepository.GetAll().ToList();
                if (search == "All" && genre=="All")
                {
                    books = _booksRepository.GetAll().ToList();
                }
                else if (search == "All" && genre != "All")
                {
                    books = _booksRepository.GetAll().Where(c=>c.Genre.Equals(genre)).ToList();
                }
                else if (search != "All" && genre == "All")
                {
                    books = _booksRepository.GetAll().Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase) || c.Author.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else
                {
                    books = _booksRepository.GetAll().Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase) || c.Author.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
                    books = books.Where(c => c.Genre.Equals(genre)).ToList();
                }
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
        public Books GetById(int id)
        {
            try
            {
                var books = _booksRepository.GetById(id);
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

        public Books UpdateBook(int id, Books books)
        {
            var book = _booksRepository.GetById(id);

            if (book != null)
            {
                book.Title = books.Title;
                book.Author = books.Author;
                book.Genre = books.Genre;
                book.Price = books.Price;
                book.PublishDate = books.PublishDate;
                var result = _booksRepository.Update(book);
                return books;
            }
            return null;
        }
    }
}
