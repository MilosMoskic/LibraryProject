using AutoMapper;
using LibraryProject.Application.Constants;
using LibraryProject.Application.Exceptions;
using LibraryProject.Application.Interfaces;
using LibraryProject.Domain.Dto;
using LibraryProject.Domain.Interfaces;
using LibraryProject.Domain.Models;

namespace LibraryProject.Application.Services
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public RentService(IRentRepository rentRepository, IUserRepository userRepository, IBookRepository bookRepository, IMapper mapper)
        {
            _rentRepository = rentRepository;
            _userRepository = userRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public RentDetails RentBook(RentBookDto rentBook)
        {
            var user = _userRepository.GetUserById(rentBook.UserId);

            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }

            if (user.Role != LibraryRoles.User)
            {
                throw new NotFoundException("You can only rent books to users.");
            }

            var book = _bookRepository.GetBook(rentBook.BookId);

            if (book == null)
            {
                throw new NotFoundException("Book not found.");
            }

            int bookRentedCount = _rentRepository.GetRentsByCondition(bookRent => bookRent.BookId == book.ID && bookRent.ReturnDate == null).Count();
            if (bookRentedCount >= book.TotalCopies)
            {
                throw new NotFoundException("There arent any available books.");
            }

            var RentBook = new BookRent()
            {
                Book = book,
                User = user,
                RentDate = DateTime.Now
            };

            _rentRepository.CreateRentBook(RentBook);

            var rentedBook = _mapper.Map<RentedBookDto>(RentBook.Book);
            var userRented = _mapper.Map<UserRentBookDto>(RentBook.User);

            var createdRent = _mapper.Map<RentDetails>(RentBook);

            return createdRent;
        }

        public ReturnDetails ReturnBook(ReturnBookDto returnBook)
        {
            var user = _userRepository.GetUserById(returnBook.UserId);

            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }

            var book = _bookRepository.GetBook(returnBook.BookId);

            if (book == null)
            {
                throw new NotFoundException("Book not found.");
            }

            var rentBookInDb = _rentRepository.FindBookRent(returnBook.BookId, returnBook.UserId);

            if (rentBookInDb == null)
            {
                throw new NotFoundException("User didn't rent that book.");
            }

            rentBookInDb.ReturnDate = DateTime.Now;

            _rentRepository.UpdateRentBook(rentBookInDb);

            var mappedReturn = _mapper.Map<ReturnDetails>(rentBookInDb);

            return mappedReturn;
        }

        public List<ReturnDetails> ListAllRentsByBook(int id)
        {
            var book = _bookRepository.GetBook(id);

            if (book == null)
            {
                throw new NotFoundException("Book not found.");
            }

            var history = _rentRepository.GetAllHistoryByBook(id);

            List<ReturnDetails> mappedHistory = _mapper.Map<List<BookRent>, List<ReturnDetails>>(history);

            return mappedHistory;
        }

        public List<ReturnDetails> ListAllRentsByUser(int id)
        {
            var user = _userRepository.GetUserById(id);

            return GetHistory(user);
        }

        public List<ReturnDetails> ListAllRentsByEmail(string email)
        {
            var user = _userRepository.GetUser(email);

            return GetHistory(user);
        }

        private List<ReturnDetails> GetHistory(User user)
        {
            if (user == null)
            {
                throw new NotFoundException("User not found.");
            }

            var history = _rentRepository.GetAllRentBooksByUser(user.ID);

            List<ReturnDetails> mappedRent = _mapper.Map<List<BookRent>, List<ReturnDetails>>(history);

            return mappedRent;
        }
    }
}
