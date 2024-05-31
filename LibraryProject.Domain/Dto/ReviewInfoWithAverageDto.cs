namespace LibraryProject.Domain.Dto
{
    public class ReviewInfoWithAverageDto
    {
        public double Average { get; set; }
        public List<ReviewInfoDto> Reviews { get; set; }
    }
}
