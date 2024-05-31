using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Domain.Models
{
    public class Author
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
