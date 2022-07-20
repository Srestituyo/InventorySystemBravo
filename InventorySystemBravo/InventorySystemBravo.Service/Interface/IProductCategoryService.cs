using InventorySystemBravo.Domain.Entities;

namespace InventorySystemBravo.Service.Interface;

public interface IProductCategoryService
{
    Task AddProductCategory(ProductCategory theProductCategory);
    
    Task<ProductCategory> GetProductCategoryById(Guid theProductCategoryId);

    Task<List<ProductCategory>> GetAllProductCategory();

    Task UpdateProductCategory(ProductCategory theProductCategory);

    Task RemoveProductCategory(ProductCategory theProductCategory);
}