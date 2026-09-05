using MyStore.ModelsView;
using MyStore.Pages.Models;
using MyStore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyStore.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly ProductRepository _repProduct;

        public DeleteModel(ProductRepository repProduct)
        {
            _repProduct = repProduct;
        }

        public Product Product { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            Product = await _repProduct.GetByIdAsync(id);
            if (Product is null) { 
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int id) {
            Product = await _repProduct.GetByIdAsync(id);
            if (Product is null)
            {
                return NotFound();
            }

            await _repProduct.DeleteAsync(id);
            return RedirectToPage("Index");
        }
    }
}
