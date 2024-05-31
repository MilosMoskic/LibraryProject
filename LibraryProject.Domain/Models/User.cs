using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Domain.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public ICollection<BookRent> BookRents { get; set; }
        public ICollection<BookReview> BookReviews { get; set; }
    }
}
