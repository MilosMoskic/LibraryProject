using LibraryProject.Domain.Dto;

namespace LibraryProject.Application.Interfaces
{
    public interface IBookReviewService
    {
        ReviewInfoWithAverageDto GetBookReviews(int bookId);
        ReviewInfoDto AddReview(ReviewDto bookReviewDto, string email);
        ReviewInfoDto UpdateReview(int bookId, string email, UpdateReviewInfoDto updateReviewInfo);
        List<ReviewInfoDto> GetUserReviews(string email);
    }
}
