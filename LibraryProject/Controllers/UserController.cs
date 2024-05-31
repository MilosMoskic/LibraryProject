using LibraryProject.Application.Constants;
using LibraryProject.Application.Interfaces;
using LibraryProject.Domain.Dto;
using LibraryProject.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        
        public UsersController(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;            
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="user">The ID of the author to delete.</param>
        [Authorize(Roles = LibraryRoles.Librarian)]
        [HttpPost("UserRegistration")]
        public ActionResult<UserDto> RegisterUser([FromBody] RegistrationUserDto user)
        {
            string role = LibraryRoles.User;
            _userService.Register(user, role);

            var response = new { message = "User created successfully." };
            return Ok(response);
        }

        /// <summary>
        /// Registers a new librarian.
        /// </summary>
        [Authorize(Roles = LibraryRoles.Admin)]
        [HttpPost("LibrarianRegistration")]
        public ActionResult<UserDto> RegisterLibrarian([FromBody] RegistrationUserDto user)
        {
            string role = LibraryRoles.Librarian;
            _userService.Register(user, role);

            var response = new { message = "Librarian created successfully." };
            return Ok(response);
        }

        /// <summary>
        /// Checks login parameters.
        /// </summary>
        [HttpPost("login")]
        public ActionResult<User> Login(LoginUserDto loginUser)
        {
            var loggedUser = _userService.LoginUser(loginUser);
            var token = _tokenHelper.CreateToken(loggedUser);

            return Ok(new { token });
        }

        [Authorize(Roles = LibraryRoles.Librarian)]
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();

            return Ok(users);
        }
    }
}
