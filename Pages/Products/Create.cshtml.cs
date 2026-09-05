using MyStore.ModelsView;
using MyStore.Pages.Models;
using MyStore.Repositories;
using MyStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace MyStore.Pages.Products
{
    [Authorize(Roles ="Admin,Editor")]
    public class CreateModel : PageModel
    {
        private readonly ProductRepository _repProduct;
        private readonly CategoryRepository _repCategory;
        private readonly IUploadService _upload;

        public CreateModel(ProductRepository repProduct , CategoryRepository repCategory , IUploadService upload)
        {
            _repProduct = repProduct;
            _repCategory = repCategory;
            _upload = upload;
        }
        [BindProperty]
        public Prodect Product {  get; set; }

        public SelectList Categories { get; set; }
        
        public async Task OnGet()
        {
            Categories = new SelectList(await _repCategory.GetAllAsync(), "CategoryId", "Name");
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) {
                Categories = new SelectList(await _repCategory.GetAllAsync(), "CategoryId", "Name");
                return Page();
            }
            if(Product.Image == null)
            {
                Categories = new SelectList(await _repCategory.GetAllAsync(), "CategoryId", "Name");
                ModelState.AddModelError("Product.Image", "Please Choose an Image");
                return Page();
            }
            Product newProduct = new Product
            {
                Name = Product.Name,
                Price = Product.Price,
                StockQuantity = Product.StockQuantity,
                CategoryId = Product.CategoryId,
            };
            try {
                newProduct.ImageUrl = _upload.Upload(Product.Image);
            
            }
            catch (Exception ex) {
                Categories = new SelectList(await _repCategory.GetAllAsync(), "CategoryId", "Name");
                ModelState.AddModelError("Product.Image", ex.Message);
               return Page();
            }

            await _repProduct.AddAsync(newProduct);
            return RedirectToPage("Index");
        }

        
    }
}
