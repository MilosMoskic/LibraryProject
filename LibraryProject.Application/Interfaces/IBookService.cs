using LibraryProject.Application.Helper.Pagination;
using LibraryProject.Domain.Dto;

namespace LibraryProject.Application.Interfaces
{
    public interface IBookService
    {
        PagedList<BookDetailsDto> GetAllBooks(PaginationQueryObject query, FilterDto filterDto, SortDto sortDto);
        BookDetailsDto GetBook(int id);
        BookDetailsDto CreateBook(BookDto book);
        BookDetailsDto UpdateBook(BookDto book, int id);
        List<BookDetailsDto> FilterAndSortBooks(FilterAndSortDto filter);
        bool DeleteBook(int id);
    }
}
