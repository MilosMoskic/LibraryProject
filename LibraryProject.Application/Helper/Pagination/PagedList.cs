using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Application.Helper.Pagination
{
    public class PagedList<T>
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItemCount { get; set; }
        public int TotalPageCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPageCount;
        public List<T> Items { get; }

        public PagedList(IEnumerable<T> items, int pageSize, int currentPage, int totalItemCount)
        {
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalItemCount = totalItemCount;
            TotalPageCount = (int)Math.Ceiling(TotalItemCount / (double)PageSize);
            Items = items.ToList();
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> items, int pageIndex, int pageSize)
        {
            var count = await items.CountAsync();

            var pagedItems = await items.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToListAsync();
            return new PagedList<T>(pagedItems, pageSize, pageIndex, count);
        }
    }
}
