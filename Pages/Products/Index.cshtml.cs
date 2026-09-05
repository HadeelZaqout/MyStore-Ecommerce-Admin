using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyStore.Models;
using MyStore.Pages.Models;
using MyStore.Repositories;
using MyStore.Extensions;

namespace MyStore.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ProductRepository _repProduct;
        private readonly CategoryRepository _repCat;

        public PaginatedList<Product> Products { get; set; } 
        [BindProperty(SupportsGet = true)]
        public string? Search { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? CategoryId { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SortField { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; }
        public SelectList Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;
        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;

        public int TotalPages { get; set; }

        public IndexModel(ProductRepository repProduct,CategoryRepository repCat) 
        {
            _repProduct = repProduct;
            _repCat = repCat;
        }

        public async Task OnGetAsync()
        {
            Categories = new SelectList(await _repCat.GetAllAsync(), "CategoryId", "Name");
            
            var query =  _repProduct.GetallQuerable();


            if (!string.IsNullOrWhiteSpace(Search))
            {
                query = query.Where(p => p.Name.Contains(Search));
                    
            }
            if (CategoryId.HasValue) {
                 query = query.Where(p => p.CategoryId == CategoryId);
            }

            string sorder = "";
            if (SortOrder != null && SortOrder.Contains("_")) {
                sorder = "desc";
            }

            query = query.ApplySorting(SortField, sorder);
            //switch(SortOrder)
            //{
            //    case "Title":
            //        query = query.OrderBy(p=>p.Name);
            //        break;
            //    case "Title_desc":
            //        query = query.OrderByDescending(p => p.Name);
            //        break;
            //    case "Price":
            //        query = query.OrderBy(p => p.Price);
            //        break;
            //    case "Price_desc":
            //        query = query.OrderByDescending(p => p.Price);
            //        break;
            //    default:
            //        query = query.OrderBy(p => p.ProductId);
            //        break; 
            //}


            Products = await PaginatedList<Product>.CreateAsync(query,PageIndex,PageSize);
           
        }
    }
}
