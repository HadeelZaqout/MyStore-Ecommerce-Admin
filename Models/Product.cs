using MyStore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Pages.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required,StringLength(100,MinimumLength =5,ErrorMessage ="This field must be between 5 and 100 chars")]
        public string Name { get; set; }

        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "This field must be between 5 and 100 chars")]
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        [NotMapped]
        public string PriceStr { get => $"{Price}  <img src=\"/images/icons/shekel_10828970.png\" width='16' />"; }
        public int StockQuantity { get; set; }

        [Column("LastUpdated",TypeName ="date") ]
        public DateTime Updated {  get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ProductImages> ProductImages { get; set; }
    }
}
