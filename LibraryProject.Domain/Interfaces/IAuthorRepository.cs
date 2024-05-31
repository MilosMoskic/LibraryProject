using LibraryProject.Domain.Models;

namespace LibraryProject.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        IQueryable<Author> GetAllAuthors();
        Author GetAuthor(int id);
        Author CreateAuthor(Author author);
        Author UpdateAuthor(Author author);
        bool DeleteAuthor(int id);
    }
}
