
namespace Solid.Ecommerce.Application.Interfaces.Servcices;
public interface IProductService
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetOne(int productId);
    Task Add(Product product);
    Task Update (Product product);
    Task Delete (int productId);
    
}
