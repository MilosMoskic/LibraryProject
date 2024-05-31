namespace LibraryProject.Domain.Dto
{
    public class ReviewInfoDto
    {
        public string UserName { get; set; }
        public string Title { get; set; }   
        public int Rating { get; set; }
        public string Description { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
