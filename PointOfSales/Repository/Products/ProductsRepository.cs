
using PointOfSales.Models;

namespace PointOfSales.Repository.Products
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly PosDbContext _context;
        public ProductsRepository(PosDbContext context)
        {
            _context = context;
        }

        public int AddProduct(Product product)
        {
            _context.Add(product);
            return _context.SaveChanges();
        }

        public int DeleteProduct(int id)
        {
            var product = _context.Product.Find(id);
            _context.Remove(product);
            return _context.SaveChanges();
        }

        public Product getProductById(int id)
        {
            return _context.Product.Find(id);
        }

        public List<Product> GetProducts()
        {
            return _context.Product.ToList();
        }

        public int UpdateProduct(Product product)
        {
            _context.Update(product);
            return _context.SaveChanges();
        }
    }
}
