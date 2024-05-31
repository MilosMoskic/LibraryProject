using LibraryProject.Domain.Interfaces;
using LibraryProject.Domain.Models;
using LibraryProject.Infastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Infastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public IQueryable<Book> GetAllBooks()
        {
            return _context.Books
                .Include(x => x.Authors);
        }

        public Book GetBook(int id)
        {

            var book = _context.Books
                .Include(x => x.Authors)
                .Where(x => !x.IsDeleted)
                .FirstOrDefault(x => x.ID == id);

            return book;
        }

        public Book CreateBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return book;
        }

        public Book UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();

            return book;
        }

        public bool DeleteBook(int id)
        {
            var bookInDb = _context.Books.FirstOrDefault(x => x.ID == id);
            if (bookInDb == null)
            {
                return false;
            }
            bookInDb.IsDeleted = true;
            bookInDb.ModifiedAt = DateTime.Now;

            return true;
        }
    }
}
