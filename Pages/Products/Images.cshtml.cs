using MyStore.Models;
using MyStore.Pages.Models;
using MyStore.Repositories;
using MyStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyStore.Pages.Products
{
    public class ImagesModel : PageModel
    {
        private readonly ProductRepository _repProduct;
        private readonly IUploadService _upload;

        public ImagesModel(ProductRepository repProduct , IUploadService upload)
        {
            _repProduct = repProduct;
            _upload = upload;
        }

        public Product Product { get; set; }

        public List<ProductImages> Images { get; set; } = new List<ProductImages>();

        [BindProperty]
        public List<IFormFile> ExtraImages { get; set; }

        private async Task CreateViewModel(int id) {
            Product = await _repProduct.GetByIdAsync(id);
            if (Product is null) { return; }
            Images = await _repProduct.GetImagesAsync(id);

        }


        public async Task<IActionResult> OnGet(int id)
        {
            await CreateViewModel(id);

            if (Product is null) { return NotFound(); }

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                await CreateViewModel(id);
                return Page();
            }

            if (ExtraImages != null && ExtraImages.Any()) 
            {
                foreach (var image in ExtraImages) {
                    try {
                       var imgUrl =  _upload.Upload(image);
                        await _repProduct.AddImageAsync(new ProductImages { ProductId = id, ImageUrl = imgUrl });
                    
                    }
                    catch(Exception er) {
                        await CreateViewModel(id);
                        ModelState.AddModelError("ExtraImages",er.Message);
                        return Page();
                    }
                }
            }

            return RedirectToPage(new {id = id});

        }
        public async Task<IActionResult> OnPostDelete(int id ,int imgId)
        {
            await _repProduct.DeleteImage(imgId);
            return RedirectToPage(new { id = id });

        }
    }
}
