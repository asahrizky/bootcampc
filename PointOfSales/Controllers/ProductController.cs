using Microsoft.AspNetCore.Mvc;
using PointOfSales.Models;

namespace PointOfSales.Controllers
{
    public class ProductController : Controller
    {
        private readonly PosDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // untuk image
        public ProductController(PosDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context; //set context
            _webHostEnvironment = webHostEnvironment; //set Environtment Default Path wwwRoot
        }
        public IActionResult Index()
        {
            var listProduct = _context.Product.ToList();
            return View(listProduct);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product item)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileName(item.ImageFile.FileName);
            string extension = Path.GetExtension(item.ImageFile.FileName);

            item.Image = fileName += extension;
            Directory.CreateDirectory(wwwRootPath + "/Image");
            string path = Path.Combine(wwwRootPath + "/Image", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                item.ImageFile.CopyTo(fileStream);
            }
            item.CreatedDate = DateTime.Now;

            _context.Add(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var product = _context.Product.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product item)
        {
            var product = _context.Product.Find(item.Id);
            if (item.ImageFile != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileName(item.ImageFile.FileName);
                string extension = Path.GetExtension(item.ImageFile.FileName);

                item.Image = fileName += extension;
                Directory.CreateDirectory(wwwRootPath + "/Image");
                string path = Path.Combine(wwwRootPath + "/Image", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    item.ImageFile.CopyTo(fileStream);
                }
            }
            product.Name = item.Name;
            product.Description = item.Description;
            product.Price = item.Price;
            product.UpdatedDate = DateTime.Now;
            _context.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var product = _context.Product.Find(id);
            _context.Remove(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}
