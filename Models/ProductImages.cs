using MyStore.Pages.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Models
{
    public class ProductImages
    {
        [Key]
        public int ProductImageId { get; set; }

        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "This field must be between 5 and 100 chars")]
        public string ImageUrl { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
