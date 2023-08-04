using Microsoft.AspNetCore.Mvc;
using PointOfSales.Models;
using PointOfSales.Repository.Categories;

namespace PointOfSales.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public CategoryController(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository; 
        }
        public IActionResult Index()
        {
            var listCategory = _categoryRepository.GetCategories();
            return View(listCategory);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category item)
        {
            item.CreatedDate = DateTime.Now;
            item.UpdatedDate = DateTime.Now;

            _categoryRepository.AddCategory(item);

            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category item)
        {
            var category = _categoryRepository.GetCategoryById(item.Id);
            category.Name = item.Name;
            category.UpdatedDate = DateTime.Now;
            _categoryRepository.UpdateCategory(category);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category =_categoryRepository.GetCategoryById(id);
            _categoryRepository.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
