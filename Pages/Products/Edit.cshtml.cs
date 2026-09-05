using MyStore.ModelsView;
using MyStore.Pages.Models;
using MyStore.Repositories;
using MyStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyStore.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ProductRepository _repProduct;
        private readonly CategoryRepository _repCategory;
        private readonly IUploadService _upload;

        public EditModel(ProductRepository repProduct, CategoryRepository repCategory, IUploadService upload)
        {
            _repProduct = repProduct;
            _repCategory = repCategory;
            _upload = upload;
        }
        [BindProperty]
        public Prodect Product { get; set; }

        public SelectList Categories { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            Categories = new SelectList(await _repCategory.GetAllAsync(), "CategoryId", "Name");

            Product p= await _repProduct.GetByIdAsync(id);
            if (p == null)
            {
                return NotFound();
            }
            Product = new Prodect();
            Product.Name = p.Name;
            Product.Price = p.Price;
            Product.CategoryId = p.CategoryId;
            Product.StockQuantity = p.StockQuantity;
            Product.ImageUrl = p.ImageUrl;
            Product.ProductId = p.ProductId;

            return Page();
        }

        public async Task<IActionResult> OnPost(int id) 
        {
            if (!ModelState.IsValid) {

                Categories = new SelectList(await _repCategory.GetAllAsync(), "CategoryId", "Name");
                return Page();
            }
            Product newProduct = new Product
            {
                ProductId = Product.ProductId,
                Name = Product.Name,
                Price = Product.Price,
                StockQuantity = Product.StockQuantity,
                CategoryId = Product.CategoryId,
                Updated = DateTime.Now,
                ImageUrl = Product.ImageUrl
            };
            if (Product.Image != null)
            {
                try
                {
                    newProduct.ImageUrl = _upload.Upload(Product.Image);

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Product.Image", ex.Message);
                    return Page();
                }
            }

            await _repProduct.UpdateAsync(newProduct);
            return RedirectToPage("Index");
        
        }
    }
}
