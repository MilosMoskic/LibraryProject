using LibraryProject.Domain.Models;

namespace LibraryProject.Domain.Interfaces
{
    public interface IBookReviewRepository
    {
        BookReview Add(BookReview bookReview);
        BookReview Update(BookReview bookReview);
        IQueryable<BookReview> GetBookReviews(int bookId);
        IQueryable<BookReview> GetUserReviews(int userId);
    }
}
