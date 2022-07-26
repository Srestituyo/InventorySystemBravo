using InventorySystemBravo.Domain.Entities;

namespace InventorySystemBravo.Repository.Interface;

public interface IProductRepository
{
    Task AddProduct(Product theProduct);
    
    Task<Product> GetProductById(Guid theProductId);

    Task<List<Product>> GetAllProduct();

    Task UpdateProduct(Product theProduct);

    Task RemoveProduct(Product theProduct);
}