using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Domain.Models
{
    public class BookRent
    {
        [Key]
        public int ID { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
