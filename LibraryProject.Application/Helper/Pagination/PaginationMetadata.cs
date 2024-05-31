namespace LibraryProject.Application.Helper.Pagination
{
    public class PaginationMetadata
    {
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
        public int TotalPageCount { get; set; }
        public int TotalItemCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string PreviousPageUrl { get; set; }
        public string NextPageUrl { get; set; }
    }
}
