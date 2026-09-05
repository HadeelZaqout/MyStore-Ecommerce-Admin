using MyStore.Models;
using MyStore.Pages;
using MyStore.Pages.Models;
using Microsoft.EntityFrameworkCore;
using MyStore.Data;

namespace MyStore.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductRepository(ApplicationDbContext context , IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IQueryable<Product> GetallQuerable() => _context.Products.Include(p => p.Category).AsNoTracking().AsQueryable();
        public async Task<List<Product>> GetAllAsync() 
        {
           return await _context.Products.Include(p => p.Category).ToListAsync();
           
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.Include(p=>p.Category).FirstOrDefaultAsync(p => p.ProductId == id);

        }

        public async Task<IEnumerable<Product>> Get(string query)
        {
            return await _context.Products.Where(p=>p.Name.Contains(query,StringComparison.OrdinalIgnoreCase)).ToListAsync();

        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product != null)
            {
            //    product.IsDeleted = true;
            //    await _context.SaveChangesAsync();

                if(product.ImageUrl.Length > 0)  
                DeletePhysicalFile(product.ImageUrl);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            else {
                throw new Exception($"Unable To Find the Product with {id}");
            }
        }

        public async Task AddImageAsync(ProductImages productImage)
        {
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteImage(int imageId)
        {
            var image = await _context.ProductImages.FindAsync(imageId);
            if (imageId == null) { return; }
            DeletePhysicalFile(image.ImageUrl);
            _context.ProductImages.Remove(image);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductImages>> GetImagesAsync(int productId)
        {
            return await _context.ProductImages.Where(p=>p.ProductId == productId).ToListAsync();
        }

        private void DeletePhysicalFile(string imgUrl)
        {
            if (string.IsNullOrEmpty(imgUrl))
            {
                return;
                
            }
            var filePath =Path.Combine(_env.WebRootPath, imgUrl.TrimStart('/'));
            if (File.Exists(filePath)) { 
                  
                  File.Delete(filePath);
            }
        }

    } 
}
