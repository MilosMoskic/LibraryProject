using LibraryProject.Application.Constants;
using LibraryProject.Application.Helper.Pagination;
using LibraryProject.Application.Interfaces;
using LibraryProject.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Authorize(Roles = LibraryRoles.Librarian)]
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IRentService _rentService;
        private readonly IBookReviewService _bookReviewService;

        public BookController(IBookService bookService, IRentService rentService, IBookReviewService bookReviewService)
        {
            _bookService = bookService;
            _rentService = rentService;
            _bookReviewService = bookReviewService;
        }

        /// <summary>
        /// Return all Books.
        /// </summary>
        [AllowAnonymous]
        [PaginatedHttpGet("GetAllBooks")]
        public ActionResult GetAllBooks([FromQuery] PaginationQueryObject query, [FromQuery] FilterDto filterDto, [FromQuery] SortDto sortDto)
        {
            var books = _bookService.GetAllBooks(query, filterDto, sortDto);

            this.AddPaginationMetadata(books, query);

            return Ok(books.Items);
        }

        /// <summary>
        /// Return a book with specific ID.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult GetBook(int id)
        {
            var book = _bookService.GetBook(id);
            return Ok(book);
        }

        /// <summary>
        /// Create a book.
        /// </summary>
        [HttpPost]
        public ActionResult CreateBook([FromBody] BookDto createBookDto)
        {
            _bookService.CreateBook(createBookDto);

            var response = new { message = "Book added successfully." };
            return Ok(response);
        }

        /// <summary>
        /// Updates a Book.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult UpdateBook([FromBody] BookDto createBookDto, int id)
        {
            _bookService.UpdateBook(createBookDto, id);

            var response = new { message = "Book updated successfully." };
            return Ok(response);

        }

        /// <summary>
        /// Deletes a Book.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);

            var response = new { message = "Book deleted successfully." };
            return Ok(response);
        }

        /// <summary>
        /// Return renting history of a Book.
        /// </summary>
        [Authorize(Roles = LibraryRoles.Librarian + " ," + LibraryRoles.Admin)]
        [HttpGet("{id}/rent-history")]
        public ActionResult GetAllBooksHistory(int id)
        {
            var history = _rentService.ListAllRentsByBook(id);
            return Ok(history);
        }

        /// <summary>
        /// Rweturns all reviews of a Book.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}/book-reviews")]
        public ActionResult GetBookReviews(int id)
        {
            var bookReviews = _bookReviewService.GetBookReviews(id);

            return Ok(bookReviews);
        }

        /// <summary>
        /// Applys filters and sorting for Books.
        /// </summary>
        [AllowAnonymous]
        [HttpGet("filter")]
        public ActionResult FilterBooks([FromQuery] FilterAndSortDto filter)
        {
            var filteredBooks = _bookService.FilterAndSortBooks(filter);

            return Ok(filteredBooks.ToList());
        }
    }
}
