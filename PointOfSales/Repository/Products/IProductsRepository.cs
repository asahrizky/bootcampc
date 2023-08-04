using PointOfSales.Models;

namespace PointOfSales.Repository.Products
{
    public interface IProductsRepository
    {
        List<Product> GetProducts();
        Product getProductById(int id);
        int AddProduct(Product product);
        int UpdateProduct(Product product); 
        int DeleteProduct(int id);
    }
}
