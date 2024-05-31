using LibraryProject.Application.Constants;
using LibraryProject.Application.Interfaces;
using LibraryProject.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRentService _rentService;
        private readonly IBookReviewService _bookReviewService;

        public ProfileController(IUserService userService, IRentService rentService, IBookReviewService bookReviewService)
        {
            _userService = userService;
            _rentService = rentService;
            _bookReviewService = bookReviewService;
        }

        /// <summary>
        /// Updates user's data.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/v1/Profile
        ///     {
        ///         "username": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="user">User information to be updated</param>
        /// <returns>A response indicating success or failure</returns>
        [Authorize]
        [HttpPut]
        public ActionResult UpdateUser(UpdateUserInfoDto user)
        {
            string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            _userService.UpdateUser(email, user);

            var response = new { message = "User updated successfully." };
            return Ok(response);
        }

        /// <summary>
        /// Changes users password.
        /// </summary>
        [Authorize]
        [HttpPut("change-password")]
        public ActionResult ChangePassword(ChangePasswordDto user)
        {
            string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            _userService.UpdateUserPassword(email, user);

            var response = new { message = "Password updated successfully." };
            return Ok(response);
        }

        /// <summary>
        /// Lists all rents of a selected user.
        /// </summary>
        [Authorize(Roles = LibraryRoles.User)]
        [HttpGet("my-history")]
        public IActionResult ListAllUserRents()
        {
            string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var history = _rentService.ListAllRentsByEmail(email);

            return Ok(history);
        }

        /// <summary>
        /// Lists all reviews of a loged-in user.
        /// </summary>
        [Authorize(Roles = LibraryRoles.User)]
        [HttpGet("my-profile")]
        public IActionResult GetMyData()
        {
            string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var userData = _userService.GetUser(email);

            return Ok(userData);
        }

        [Authorize(Roles = LibraryRoles.User)]
        [HttpGet("user-reviews")]
        public ActionResult GetBookReviews()
        {
            string email = HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var userReviews = _bookReviewService.GetUserReviews(email);

            return Ok(userReviews);
        }
    }
}

