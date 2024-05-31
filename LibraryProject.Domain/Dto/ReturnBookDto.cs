namespace LibraryProject.Domain.Dto
{
    public class ReturnBookDto
    {
        public int UserId { get; set; }
        public UserRentBookDto? User { get; set; }
        public int BookId { get; set; }
        public RentedBookDto? Book { get; set; }
    }
}
