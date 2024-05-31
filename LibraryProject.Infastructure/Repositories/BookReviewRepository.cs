using LibraryProject.Domain.Interfaces;
using LibraryProject.Domain.Models;
using LibraryProject.Infastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Infastructure.Repositories
{
    public class BookReviewRepository : IBookReviewRepository
    {
        private readonly LibraryContext _context;
        public BookReviewRepository(LibraryContext context)
        {
            _context = context;
        }

        public BookReview Add(BookReview bookReview)
        {
            _context.BookReviews.Add(bookReview);
            _context.SaveChanges();

            return bookReview;
        }

        public BookReview Update(BookReview bookReview)
        {
            _context.Update(bookReview);
            _context.SaveChanges();

            return bookReview;
        }

        public IQueryable<BookReview> GetBookReviews(int bookId)
        {
            return _context.BookReviews
                .Include(br => br.Book)
                .Include(br => br.User)
                .Where(br => br.BookId == bookId);
        }

        public IQueryable<BookReview> GetUserReviews(int userId)
        {
            return _context.BookReviews
                .Include(br => br.Book)
                .Where(br => br.UserId == userId);
        }

    }
}
