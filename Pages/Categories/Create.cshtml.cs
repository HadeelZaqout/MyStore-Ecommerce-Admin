using MyStore.Models;
using MyStore.ModelsView;
using MyStore.Pages.Models;
using MyStore.Repositories;
using MyStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyStore.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly CategoryRepository _repCategory;
        private readonly IUploadService _upload;

        public CreateModel(CategoryRepository repCategory, IUploadService upload)
        {
            _repCategory = repCategory;
            _upload = upload;
        }
        [BindProperty]
        public CatViewModel category { get; set; }
        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (category.Image == null)
            {
                ModelState.AddModelError("Product.Image", "Please Choose an Image");
                return Page();
            }

            Category newCat = new Category
            {
                Name = category.Name, 
            };
            try
            {
                newCat.ImageUrl = _upload.Upload(category.Image,"Categories");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("category.Image", ex.Message);
                return Page();
            }

            await _repCategory.AddAsync(newCat);
            return RedirectToPage("Index");
        }

    }
}
