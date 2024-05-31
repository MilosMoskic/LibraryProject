using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Domain.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public int NumberOfPages { get; set; }
        public int PublishingYear { get; set; }
        public int TotalCopies { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<BookRent> BookRents { get; set; }
        public ICollection<BookReview> BookReviews { get; set; }
    }
}
