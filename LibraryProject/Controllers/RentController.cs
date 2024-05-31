using Azure;
using LibraryProject.Application.Constants;
using LibraryProject.Application.Interfaces;
using LibraryProject.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [Authorize(Roles = LibraryRoles.Librarian)]
    [ApiController]
    [Route("api/")]
    public class RentController : Controller
    {
        private readonly IRentService _rentService;
        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }

        /// <summary>
        /// Rents a book to a user.
        /// </summary>
        [HttpPost("rent")]
        public ActionResult Rent([FromBody] RentBookDto rentBook)
        {
            _rentService.RentBook(rentBook);

            var response = new { message = "Book rented successfully." };
            return Ok(response);
        }

        /// <summary>
        /// Returns a book from a user.
        /// </summary>
        [HttpPut("return")]
        public ActionResult ReturnBook([FromBody] ReturnBookDto returnBook)
        {
            _rentService.ReturnBook(returnBook);

            var response = new { message = "Book returned successfully." };
            return Ok(response);
        }

        /// <summary>
        /// Returns all rents of a specific user.
        /// </summary>
        [HttpGet("users/{id}/rent-history")]
        public ActionResult ListAllRents(int id)
        {
            var history = _rentService.ListAllRentsByUser(id);

            return Ok(history);
        }
    }
}