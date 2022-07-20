using InventorySystemBravo.Domain.Entities;

namespace InventorySystemBravo.Service.Interface;

public interface IProductService
{
    Task AddProduct(Product theProduct);
    
    Task<Product> GetProductById(Guid theProductId);

    Task<List<Product>> GetAllProduct();

    Task UpdateProduct(Product theProduct);

    Task RemoveProduct(Product theProduct);
}