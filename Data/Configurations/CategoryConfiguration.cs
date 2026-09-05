using MyStore.Models;
using MyStore.Pages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Net.Mime.MediaTypeNames;

namespace MyStore.Data.Configurations
{
    public class CategoryConfiguration :IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            
            builder.HasData(new List<Category>(){
                new Category {CategoryId = 1, Name = "IT" ,ImageUrl="/images/Products/default.png"},
                new Category {CategoryId = 2, Name = "Toys" ,ImageUrl="/images/Products/default.png"},
                new Category {CategoryId = 3, Name = "Home" ,ImageUrl="/images/Products/default.png"},
            });
        }
    }
}

