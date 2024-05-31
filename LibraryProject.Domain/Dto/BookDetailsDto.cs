namespace LibraryProject.Domain.Dto
{
    public class BookDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }        
        public string Genre { get; set; }
        public int NumberOfPages { get; set; }
        public int PublishingYear { get; set; }       
        public ICollection<BookAuthorDto> Authors { get; set; }
    }
}
