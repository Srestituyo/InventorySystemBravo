using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using InventorySystemBravo.Service.Interface;

namespace InventorySystemBravo.Service.Service;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _theProductCategoryRepository;

    public ProductCategoryService(IProductCategoryRepository theProductCategoryRepository)
    {
        _theProductCategoryRepository = theProductCategoryRepository;
    }

    public async Task AddProductCategory(ProductCategory theProductCategory)
    {
        await _theProductCategoryRepository.AddProductCategory(theProductCategory);
    }

    public async Task<ProductCategory> GetProductCategoryById(Guid theProductCategoryId)
    {
        var aProductCategory = await _theProductCategoryRepository.GetProductCategoryById(theProductCategoryId);
        return aProductCategory;
    }

    public async Task<List<ProductCategory>> GetAllProductCategory()
    {
        var aProductCategoryList = await _theProductCategoryRepository.GetAllProductCategory();
        return aProductCategoryList;
    }

    public async Task UpdateProductCategory(ProductCategory theProductCategory)
    {
        await _theProductCategoryRepository.UpdateProductCategory(theProductCategory);
    }

    public async Task RemoveProductCategory(ProductCategory theProductCategory)
    {
        await _theProductCategoryRepository.RemoveProductCategory(theProductCategory);
    }
}