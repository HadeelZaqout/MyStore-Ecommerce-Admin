using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using MyStore.Models;
using MyStore.Pages;
using MyStore.Pages;
using MyStore.Pages.Models;

namespace MyStore.Repositories
{
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryRepository(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IQueryable<Category> GetallQuerable() => _context.Categories.AsNoTracking().AsQueryable();

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(p => p.CategoryId == id);
        }

        public async Task<IEnumerable<Category>> Get(string query)
        {
            return await _context.Categories.Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }
        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await GetByIdAsync(id);
            if (category != null)
            {
                if (category.ImageUrl.Length > 0)
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Unable To Find the Category with {id}");
            }
        }
    }
}
