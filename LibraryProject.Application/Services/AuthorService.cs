using AutoMapper;
using LibraryProject.Application.Exceptions;
using LibraryProject.Application.Helper.Pagination;
using LibraryProject.Application.Interfaces;
using LibraryProject.Domain.Dto;
using LibraryProject.Domain.Interfaces;
using LibraryProject.Domain.Models;

namespace LibraryProject.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public PagedList<AuthorDetails> GetAllAuthors(PaginationQueryObject query)
        {
            var authorsInDb = _authorRepository.GetAllAuthors();

            var totalCount = authorsInDb.Count();
            var authors = authorsInDb.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize).ToList();

            var mappedAuthors = _mapper.Map<List<AuthorDetails>>(authors);

            return new PagedList<AuthorDetails>(mappedAuthors, query.PageSize, query.PageNumber, totalCount);
        }

        public AuthorDetails GetAuthor(int id)
        {
            var author = _authorRepository.GetAuthor(id);

            if (author == null)
            {
                throw new NotFoundException("Author not found");
            }

            var mappedAuthor = _mapper.Map<AuthorDetails>(author);

            return mappedAuthor;
        }

        public AuthorDetails CreateAuthor(AuthorDto author)
        {
            var mappedAuthor = _mapper.Map<Author>(author);

            mappedAuthor.CreatedAt = DateTime.Now;
            mappedAuthor.ModifiedAt = null;
            mappedAuthor.IsDeleted = false;

            _authorRepository.CreateAuthor(mappedAuthor);

            var mappedCreatedAuthor = _mapper.Map<AuthorDetails>(mappedAuthor);

            return mappedCreatedAuthor;
        }

        public AuthorDetails UpdateAuthor(AuthorDto author, int id)
        {
            var authorDb = _authorRepository.GetAuthor(id);

            if (authorDb == null)
            {
                throw new NotFoundException("Author not found");
            }

            _mapper.Map(author, authorDb);

            authorDb.ModifiedAt = DateTime.Now;

            _authorRepository.UpdateAuthor(authorDb);

            var updatedAuthor = _mapper.Map<AuthorDetails>(authorDb);

            return updatedAuthor;
        }

        public bool DeleteAuthor(int id)
        {
            var authorInDb = _authorRepository.GetAuthor(id);

            if (authorInDb == null)
            {
                throw new NotFoundException("Author not found");
            }

            return _authorRepository.DeleteAuthor(id);
        }
    }
}
