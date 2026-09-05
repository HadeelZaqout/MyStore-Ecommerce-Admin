using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyStore.ModelsView
{
    public class CatViewModel
    {
        public int CategoryId { get; set; }
        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "This field must be between 5 and 100 chars")]
        public string Name { get; set; }

        [DisplayName("Main Image")]
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }

    }
}
