using LibraryProject.Application.Constants;
using LibraryProject.Application.Interfaces;
using LibraryProject.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryProject.Controllers
{
    [Authorize(Roles = LibraryRoles.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class BookReviewsController : ControllerBase
    {
        private readonly IBookReviewService _bookReviewService;

        public BookReviewsController(IBookReviewService bookReviewService)
        {
            _bookReviewService = bookReviewService;
        }


        /// <summary>
        /// Crates a review for a book.
        /// </summary>
        [Authorize(Roles = LibraryRoles.User)]
        [HttpPost]
        public IActionResult Create(ReviewDto bookReviewDto)
        {
            string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            _bookReviewService.AddReview(bookReviewDto, email);

            var response = new { message = "Reviewed book successfully." };
            return Ok(response);
        }


        [HttpPut("{bookId}")]
        public IActionResult Update(int bookId, UpdateReviewInfoDto bookReviewDto)
        {
            string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            _bookReviewService.UpdateReview(bookId, email, bookReviewDto);

            var response = new { message = "Updated book review successfully." };
            return Ok(response);
        }
    }
}
