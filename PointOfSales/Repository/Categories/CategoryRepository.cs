using PointOfSales.Models;

namespace PointOfSales.Repository.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PosDbContext _context;

        public CategoryRepository(PosDbContext context)
        {
            _context = context;
        }
        public int AddCategory(Category category)
        {
            _context.Add(category);
            return _context.SaveChanges();
        }

        public int DeleteCategory(int id)
        {
           var category = _context.Category.Find(id);
            _context.Remove(category);
            return _context.SaveChanges();
        }

        public List<Category> GetCategories()
        {
           return _context.Category.ToList();
        }

        public Category GetCategoryById(int id)
        {
           return _context.Category.Find(id);
        
        }

        public int UpdateCategory(Category category)
        {
            _context.Update(category);
            return _context.SaveChanges();
        }
    }
}
