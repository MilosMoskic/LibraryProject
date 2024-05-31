using AutoMapper;
using LibraryProject.Application.Exceptions;
using LibraryProject.Application.Interfaces;
using LibraryProject.Domain.Dto;
using LibraryProject.Domain.Interfaces;
using LibraryProject.Domain.Models;

namespace LibraryProject.Application.Services
{
    public class BookReviewService : IBookReviewService
    {
        private readonly IBookReviewRepository _bookReviewRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        public BookReviewService(IBookReviewRepository bookReviewRepository, IUserRepository userRepository, IMapper mapper, IBookRepository bookRepository)
        {
            _bookReviewRepository = bookReviewRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
        }

        public ReviewInfoWithAverageDto GetBookReviews(int bookId)
        {
            var bookReviews = _mapper.Map<List<ReviewInfoDto>>(_bookReviewRepository.GetBookReviews(bookId).ToList());
            var reviewInfoWithAvgerage = new ReviewInfoWithAverageDto();
            reviewInfoWithAvgerage.Reviews = bookReviews;
            reviewInfoWithAvgerage.Average = bookReviews.Any() ? bookReviews.Average(review => review.Rating) : 0;
            
            return reviewInfoWithAvgerage;
        }
        public ReviewInfoDto AddReview(ReviewDto bookReviewDto, string email)
        {
            var user = _userRepository.GetUser(email);
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }
            var book = _bookRepository.GetBook(bookReviewDto.BookId);

            if (book == null)
            {
                throw new NotFoundException("Book not found.");
            }

            if (_bookReviewRepository.GetBookReviews(bookReviewDto.BookId).Any(u => u.User.Email == email))
            {
                throw new BadRequestException("You already reviewed this book.");
            }

            BookReview bookReview = _mapper.Map<BookReview>(bookReviewDto);
            bookReview.ReviewDate = DateTime.Now;
            bookReview.UserId = user.ID;

            var createdBookReview = _mapper.Map<ReviewInfoDto>(_bookReviewRepository.Add(bookReview));

            return createdBookReview;
        }

        public ReviewInfoDto UpdateReview(int bookId, string email, UpdateReviewInfoDto updateReviewInfo)
        {
            var user = _userRepository.GetUser(email);
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }

            var book = _bookRepository.GetBook(bookId);

            if (book == null)
            {
                throw new NotFoundException("Book not found.");
            }

            if (_bookReviewRepository.GetBookReviews(bookId).Any(u => u.User.Email == email) != true)
            {
                throw new BadRequestException("You didn't review this book.");
            }

            BookReview bookReview = _mapper.Map<BookReview>(updateReviewInfo);
            bookReview.ReviewDate = DateTime.Now;
            bookReview.UserId = user.ID;
            bookReview.BookId = book.ID;

            var mappedUpdatedReview = _mapper.Map<ReviewInfoDto>(_bookReviewRepository.Update(bookReview));
            return mappedUpdatedReview;
        }

        public List<ReviewInfoDto> GetUserReviews(string email)
        {
            var user = _userRepository.GetUser(email);
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }            
            var userReviews = _mapper.Map<List<ReviewInfoDto>>(_bookReviewRepository.GetUserReviews(user.ID));

            return userReviews;
        }
    }
}
