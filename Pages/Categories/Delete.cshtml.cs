using MyStore.Models;
using MyStore.Pages.Models;
using MyStore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyStore.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly CategoryRepository _repCat;

        public DeleteModel(CategoryRepository repCat)
        {
            _repCat = repCat;
        }

        public Category Category { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            Category = await _repCat.GetByIdAsync(id);
            if (Category is null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            Category = await _repCat.GetByIdAsync(id);
            if (Category is null)
            {
                return NotFound();
            }

            await _repCat.DeleteAsync(id);
            return RedirectToPage("Index");
        }
    }
}

