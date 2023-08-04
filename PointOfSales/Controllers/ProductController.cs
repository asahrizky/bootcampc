using Microsoft.AspNetCore.Mvc;
using PointOfSales.Models;
using PointOfSales.Repository.Products;
namespace PointOfSales.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository _productRepository;
        private readonly IWebHostEnvironment _webHostEnvironment; // untuk image
        public ProductController(IProductsRepository productsRepository, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productsRepository; //set context
            _webHostEnvironment = webHostEnvironment; //set Environtment Default Path wwwRoot
        }
        public IActionResult Index()
        {
            var listProduct = _productRepository.GetProducts();
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

            _productRepository.AddProduct(item);
            

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var product = _productRepository.getProductById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product item)
        {
            var product = _productRepository.getProductById(item.Id);
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
            _productRepository.UpdateProduct(product);
            
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int id)
        {
            var product = _productRepository.getProductById(id);
            _productRepository.DeleteProduct(id);
            

            return RedirectToAction("Index");
        }
    }

}
