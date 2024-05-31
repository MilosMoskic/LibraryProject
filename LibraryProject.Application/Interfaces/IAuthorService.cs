using LibraryProject.Application.Helper.Pagination;
using LibraryProject.Domain.Dto;

namespace LibraryProject.Application.Interfaces
{
    public interface IAuthorService
    {
        PagedList<AuthorDetails> GetAllAuthors(PaginationQueryObject query);
        AuthorDetails GetAuthor(int id);
        AuthorDetails CreateAuthor(AuthorDto author);
        AuthorDetails UpdateAuthor(AuthorDto author, int id);
        bool DeleteAuthor(int id);
    }
}
