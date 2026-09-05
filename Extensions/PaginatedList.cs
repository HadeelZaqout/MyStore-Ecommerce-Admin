using Microsoft.EntityFrameworkCore;

namespace MyStore.Extensions
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int QueryCount { get; set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public PaginatedList(List<T> items, int Count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            QueryCount = Count;
            TotalPages = (int) Math.Ceiling(Count/(double) pageSize);
            AddRange(items);
        
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source ,int pageIndex ,int pageSize) 
        {
            var count = source.Count();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }

}
