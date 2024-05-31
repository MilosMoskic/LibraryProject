using AutoMapper;
using LibraryProject.Domain.Dto;
using LibraryProject.Domain.Models;

namespace LibraryProject.Domain.LibraryProfile
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, LoginUserDto>().ReverseMap();
            CreateMap<User, RegistrationUserDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, BookAuthorDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, BookDetailsDto>().ReverseMap();
            CreateMap<BookRent, RentBookDto>().ReverseMap();
            CreateMap<BookRent, RentDetails>().ReverseMap();
            CreateMap<BookRent, ReturnBookDto>().ReverseMap();
            CreateMap<BookRent, ReturnDetails>().ReverseMap();
            CreateMap<User, UserRentBookDto>().ReverseMap();
            CreateMap<Book, RentedBookDto>().ReverseMap();
            CreateMap<Book, ReturnBookDto>().ReverseMap();
            CreateMap<Author, AuthorDetails>().ReverseMap();
            CreateMap<BookReview, ReviewDto>().ReverseMap();
            CreateMap<UpdateReviewInfoDto, BookReview>().ReverseMap();
            CreateMap<BookReview, ReviewInfoDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Book.Title));
        }
    }
}
