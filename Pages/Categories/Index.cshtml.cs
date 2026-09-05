using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyStore.Extensions;
using MyStore.Models;
using MyStore.Pages.Models;
using MyStore.Repositories;

namespace MyStore.Pages.Categories
{
    public class IndexModel : PageModel
     {
        private readonly CategoryRepository _repCategory;

        public PaginatedList<Category> Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? Search { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;
        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;
        [BindProperty(SupportsGet = true)]
        public string SortField { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; }
        public int TotalPages { get; set; }
        public IndexModel(CategoryRepository repCategory)
        {
            _repCategory = repCategory;
        }
        public async Task OnGetAsync()
        {
            var query = _repCategory.GetallQuerable();


            if (!string.IsNullOrWhiteSpace(Search))
            {
                query = query.Where(p => p.Name.Contains(Search));

            }

            string sorder = "";
            if (SortOrder != null && SortOrder.Contains("_"))
            {
                sorder = "desc";
            }

            query = query.ApplySorting(SortField, sorder);

            Categories = await PaginatedList<Category>.CreateAsync(query, PageIndex, PageSize);

            
        }
    }
}
