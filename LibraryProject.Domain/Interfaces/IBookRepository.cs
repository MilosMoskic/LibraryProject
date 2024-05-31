using LibraryProject.Domain.Models;

namespace LibraryProject.Domain.Interfaces
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAllBooks();
        Book GetBook(int id);
        Book CreateBook(Book book);
        Book UpdateBook(Book book);
        bool DeleteBook(int id);
    }
}
