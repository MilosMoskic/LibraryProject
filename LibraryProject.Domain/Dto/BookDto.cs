namespace LibraryProject.Domain.Dto
{
    public class BookDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public int NumberOfPages { get; set; }
        public int PublishingYear { get; set; }
        public int TotalCopies { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}
