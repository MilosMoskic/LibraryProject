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
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        /// <summary>
        /// Return all Authors.
        /// </summary>
        [PaginatedHttpGet("GetAllAuthors")]
        public ActionResult GetAllAuthors([FromQuery] PaginationQueryObject query)
        {
            var authors = _authorService.GetAllAuthors(query);

            this.AddPaginationMetadata(authors, query);

            return Ok(authors.Items);
        }

        /// <summary>
        /// Return an Author.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult GetAuthor(int id)
        {
            var author = _authorService.GetAuthor(id);

            return Ok(author);
        }

        /// <summary>
        /// Creates a new Author.
        /// </summary>
        [HttpPost]
        public ActionResult CreateAuthor([FromBody] AuthorDto createAuthorDto)
        {
            _authorService.CreateAuthor(createAuthorDto);

            var response = new { message = "Author added successfully." };
            return Ok(response);
        }

        /// <summary>
        /// Updates an Author.
        /// </summary>
        [HttpPut("{id}")]
        public ActionResult UpdateAuthor([FromBody] AuthorDto updateAuthorDto, int id)
        {
            _authorService.UpdateAuthor(updateAuthorDto, id);

            var response = new { message = "Author updated successfully." };
            return Ok(response);
        }

        /// <summary>
        /// Deletes an Author.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult DeleteAuthro(int id)
        {
            _authorService.DeleteAuthor(id);

            var response = new { message = "Author successfully deleted." };
            return Ok(response);
        }
    }
}
