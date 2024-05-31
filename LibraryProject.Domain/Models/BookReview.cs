namespace LibraryProject.Domain.Models
{
    public class BookReview
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int Rating { get; set; }
        public string Description { get; set; }

        public DateTime ReviewDate { get; set; }
    }
}
