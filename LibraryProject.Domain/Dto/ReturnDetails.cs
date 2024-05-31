namespace LibraryProject.Domain.Dto
{
    public class ReturnDetails
    {
        public UserRentBookDto User { get; set; }
        public RentedBookDto Book { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
