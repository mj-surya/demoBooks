using BookStoreApp.Contexts;
using BookStoreApp.Interface;
using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Repository
{
    public class BooksRepository : IRepository<int, Books>
    {
        private readonly BooksContext _context;

        public BooksRepository(BooksContext context)
        {
            _context = context;
        }
        public Books Add(Books entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges();
            return entity;

        }
        public Books Delete(int key)
        {
            var book = GetById(key);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return book;
            }
            return null;
        }

        public IList<Books> GetAll()
        {
            if (_context.Books.Count() == 0)
                return null;
            return _context.Books.ToList();
        }

        public Books GetById(int key)
        {
            var book = _context.Books.SingleOrDefault(u => u.BookID == key);
            return book;
        }

        public Books Update(Books entity)
        {
            var book = GetById(entity.BookID);
            if (book != null)
            {
                _context.Entry<Books>(book).State = EntityState.Modified;
                _context.SaveChanges();
                return book;
            }
            return null;
        }
    }
}
