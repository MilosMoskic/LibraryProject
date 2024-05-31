namespace LibraryProject.Domain.Dto
{
    public class RentDetails
    {
        public UserDto User { get; set; }
        public RentedBookDto Book { get; set; }
        public DateTime RentDate { get; set; }
    }
}
