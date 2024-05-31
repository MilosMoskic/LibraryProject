using LibraryProject.Domain.Interfaces;
using LibraryProject.Domain.Models;
using LibraryProject.Infastructure.Context;

namespace LibraryProject.Infastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;

        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        public IQueryable<Author> GetAllAuthors()
        {
            return _context.Authors.AsQueryable();
        }

        public Author GetAuthor(int id)
        {
            var author = _context.Authors.FirstOrDefault(a => a.ID == id && !a.IsDeleted);
            return author;
        }

        public Author CreateAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();

            return author;
        }

        public Author UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();

            return author;
        }

        public bool DeleteAuthor(int id)
        {
            var authorInDb = _context.Authors.FirstOrDefault(x => x.ID == id);
            if (authorInDb == null)
            {
                return false;
            }
            authorInDb.IsDeleted = true;
            authorInDb.ModifiedAt = DateTime.Now;

            UpdateAuthor(authorInDb);

            return true;
        }
    }
}
