using Microsoft.AspNetCore.Mvc;
using PointOfSales.Models;
namespace PointOfSales.Controllers
{
    public class CategoryController : Controller
    {
        private readonly PosDbContext _context;
        
        public CategoryController(PosDbContext context) {
            _context = context; 
        }
        public IActionResult Index()
        {
            var listCategory = _context.Category.ToList();
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

            _context.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var category = _context.Category.Find(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category item)
        {
            var category = _context.Category.Find(item.Id);
            category.Name = item.Name;
            category.UpdatedDate = DateTime.Now;
            _context.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category =_context.Category.Find(id);
            _context.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
