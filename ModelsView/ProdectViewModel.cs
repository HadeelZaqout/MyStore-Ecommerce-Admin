using MyStore.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.ModelsView
{
    public class Prodect
    {
        
        public int ProductId { get; set; }

        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "This field must be between 5 and 100 chars")]
        public string Name { get; set; }
        [Range(0, 999999)]
        public double Price { get; set; }

        [Range(0, 999999)]
        [DisplayName("Stock Quantity")]
        public int StockQuantity { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [DisplayName("Main Image")]
        public IFormFile? Image { get; set; }

        public string? ImageUrl { get; set; }
    }
}