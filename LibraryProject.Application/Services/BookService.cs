using AutoMapper;
using LibraryProject.Application.Exceptions;
using LibraryProject.Application.Helper.Pagination;
using LibraryProject.Application.Helper.FilterAndSort;
using LibraryProject.Application.Interfaces;
using LibraryProject.Domain.Dto;
using LibraryProject.Domain.Interfaces;
using LibraryProject.Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Linq.Expressions;

namespace LibraryProject.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public PagedList<BookDetailsDto> GetAllBooks(PaginationQueryObject query, FilterDto filterDto, SortDto sortDto)
        {
            var booksInDb = _bookRepository.GetAllBooks();

            booksInDb = booksInDb.Filter(filterDto);
            booksInDb = booksInDb.Sort(sortDto);

            var totalCount = booksInDb.Count();
            var books = booksInDb.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize).ToList();

            var mappedBooks = _mapper.Map<List<BookDetailsDto>>(books);

            return new PagedList<BookDetailsDto>(mappedBooks, query.PageSize, query.PageNumber, totalCount);
        }

        public BookDetailsDto GetBook(int id)
        {
            var book = _bookRepository.GetBook(id);

            if (book == null)
            {
                throw new NotFoundException("Book not found.");
            }

            var mappedBook = _mapper.Map<BookDetailsDto>(book);

            return mappedBook;
        }

        public BookDetailsDto CreateBook(BookDto book)
        {
            var authors = new List<Author>();

            foreach (var id in book.AuthorIds)
            {
                var author = _authorRepository.GetAuthor(id);
                if (author == null)
                {
                    throw new NotFoundException("Author not found");
                }

                authors.Add(author);
            }

            var mappedBook = _mapper.Map<Book>(book);

            mappedBook.Authors = authors;
            mappedBook.CreatedAt = DateTime.Now;
            mappedBook.ModifiedAt = null;
            mappedBook.IsDeleted = false;

            _bookRepository.CreateBook(mappedBook);

            var createdBook = _mapper.Map<BookDetailsDto>(mappedBook);

            return createdBook;
        }

        public BookDetailsDto UpdateBook(BookDto book, int id)
        {
            var bookDb = _bookRepository.GetBook(id);

            if (bookDb == null)
            {
                throw new NotFoundException("Book not found.");
            }

            _mapper.Map(book, bookDb);

            bookDb.Authors = new List<Author>();

            foreach (var authorId in book.AuthorIds)
            {
                var author = _authorRepository.GetAuthor(id);
                if (author == null)
                {
                    throw new NotFoundException("Author not found");
                }

                bookDb.Authors.Add(author);
            }

            bookDb.ID = bookDb.ID;
            bookDb.ModifiedAt = DateTime.Now;

            _bookRepository.UpdateBook(bookDb);

            var updatedBook = _mapper.Map<BookDetailsDto>(bookDb);

            return updatedBook;
        }

        public bool DeleteBook(int id)
        {
            if (_bookRepository.GetBook(id) == null)
            {
                throw new NotFoundException("Book not found.");
            }

            return _bookRepository.DeleteBook(id);
        }

        public List<BookDetailsDto> FilterAndSortBooks(FilterAndSortDto filter)
        {
            var filteredBooks = _bookRepository.GetAllBooks()
                .Filter(filter.FilterDto)
                .Sort(filter.SortDto);

            List<BookDetailsDto> mappedBooks = _mapper.Map<List<BookDetailsDto>>(filteredBooks.ToList());

            return mappedBooks;
        }

        
    }
}
