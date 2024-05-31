using LibraryProject.Domain.Interfaces;
using LibraryProject.Domain.Models;
using LibraryProject.Infastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryProject.Infastructure.Repositories
{
    public class RentRepository : IRentRepository
    {
        private readonly LibraryContext _context;
        public RentRepository(LibraryContext context)
        {
            _context = context;
        }

        public BookRent CreateRentBook(BookRent bookRent)
        {
            _context.Add(bookRent);
            _context.SaveChanges();

            return bookRent;
        }

        public BookRent UpdateRentBook(BookRent bookRent)
        {
            _context.Update(bookRent);
            _context.SaveChanges();

            return bookRent;
        }

        public BookRent FindBookRent(int bookId, int userId)
        {
            return _context.BookRents.Where(br => br.BookId == bookId && br.UserId == userId && br.ReturnDate == null).FirstOrDefault();
        }

        public List<BookRent> GetAllRentBooksByUser(int id)
        {
            return _context.BookRents.Where(br => br.UserId == id).Include(br => br.Book).ToList();
        }

        public List<BookRent> GetAllHistoryByBook(int id)
        {
            return _context.BookRents.Where(br => br.BookId == id).Include(br => br.User).ToList();
        }

        public IEnumerable<BookRent> GetRentsByCondition(Expression<Func<BookRent, bool>> condition)
        {
            return _context.BookRents.Where(condition).ToList();
        }
    }
}
