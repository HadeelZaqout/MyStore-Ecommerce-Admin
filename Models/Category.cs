using MyStore.Pages.Models;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "This field must be between 5 and 100 chars")]
        public string Name { get; set; }

        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "This field must be between 5 and 100 chars")]
        public string ImageUrl { get; set; }
        
    }
}
