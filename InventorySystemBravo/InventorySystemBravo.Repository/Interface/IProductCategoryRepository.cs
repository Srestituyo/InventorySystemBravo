using InventorySystemBravo.Domain.Entities;

namespace InventorySystemBravo.Repository.Interface;

public interface IProductCategoryRepository
{
    Task AddProductCategory(ProductCategory theProductCategory);
    
    Task<ProductCategory> GetProductCategoryById(Guid theProductCategoryId);

    Task<List<ProductCategory>> GetAllProductCategory();

    Task UpdateProductCategory(ProductCategory theProductCategory);

    Task RemoveProductCategory(ProductCategory theProductCategory);
}