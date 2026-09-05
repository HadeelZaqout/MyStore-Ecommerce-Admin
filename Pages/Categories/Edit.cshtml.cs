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
    public class EditModel : PageModel
    {
        private readonly CategoryRepository _repCategory;
        private readonly IUploadService _upload;

        public EditModel(CategoryRepository repCategory, IUploadService upload)
        {
            _repCategory = repCategory;
            _upload = upload;
        }
        [BindProperty]
        public CatViewModel Category { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {

            Category c = await _repCategory.GetByIdAsync(id);
            if (c == null)
            {
                return NotFound();
            }
            Category = new CatViewModel();
            Category.Name = c.Name;
            Category.ImageUrl = c.ImageUrl;
            Category.CategoryId = c.CategoryId;

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Category newCat = new Category
            {
                CategoryId = Category.CategoryId,
                Name = Category.Name,
                ImageUrl = Category.ImageUrl
            };
            if (Category.Image != null)
            {
                try
                {
                    newCat.ImageUrl = _upload.Upload(Category.Image, "Categories");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("category.Image", ex.Message);
                    return Page();
                }
            }
                await _repCategory.UpdateAsync(newCat);
                return RedirectToPage("Index");
            } 
       
           

        }
    }
