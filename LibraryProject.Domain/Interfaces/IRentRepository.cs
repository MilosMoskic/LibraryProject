using LibraryProject.Domain.Models;
using System.Linq.Expressions;

namespace LibraryProject.Domain.Interfaces
{
    public interface IRentRepository
    {
        BookRent FindBookRent(int bookId, int userId);
        BookRent CreateRentBook(BookRent bookRent);
        BookRent UpdateRentBook(BookRent bookRent);
        IEnumerable<BookRent> GetRentsByCondition(Expression<Func<BookRent, bool>> condition);
        List<BookRent> GetAllRentBooksByUser(int id);
        List<BookRent> GetAllHistoryByBook(int id);
    }
}
