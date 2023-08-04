using PointOfSales.Models;

namespace PointOfSales.Repository.Categories
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        Category GetCategoryById(int id);
        int AddCategory(Category category);
        int UpdateCategory(Category category);
        int DeleteCategory(int id);
    }

}
