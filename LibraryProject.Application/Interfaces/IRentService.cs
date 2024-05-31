using LibraryProject.Domain.Dto;

namespace LibraryProject.Application.Interfaces
{
    public interface IRentService
    {
        RentDetails RentBook(RentBookDto rentBook);
        ReturnDetails ReturnBook(ReturnBookDto returnBook);
        List<ReturnDetails> ListAllRentsByUser(int id);
        List<ReturnDetails> ListAllRentsByEmail(string email);
        List<ReturnDetails> ListAllRentsByBook(int id);
    }
}
