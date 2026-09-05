using MyStore.Pages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Net.Mime.MediaTypeNames;

namespace MyStore.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder) 
        {
            builder.Property(pr => pr.Updated).HasDefaultValueSql("getdate()");
            builder.Property(pr => pr.StockQuantity).HasDefaultValue("10");
            builder.Property(pr => pr.ImageUrl).HasDefaultValue("/images/Products/default.png");
            builder.HasMany(p=>p.ProductImages).WithOne(p=>p.Product).HasForeignKey(p=>p.ProductId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Product>(){
                new Product {ProductId =1 , Name="Keyboard" ,Price=30, StockQuantity=16 ,CategoryId = 1},
                new Product {ProductId =2 , Name="Mouse" ,Price=15 ,CategoryId = 2},
                new Product {ProductId =3 , Name="Lights" ,Price=22, StockQuantity=50 ,CategoryId = 1}
            });
        }
    }
}
