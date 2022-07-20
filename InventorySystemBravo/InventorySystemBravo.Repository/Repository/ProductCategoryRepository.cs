using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventorySystemBravo.Repository.Repository;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly ApplicationDbContext _theApplicationDbContext;

    public ProductCategoryRepository(ApplicationDbContext theApplicationDbContext)
    {
        _theApplicationDbContext = theApplicationDbContext;
    }

    public async Task<ProductCategory> GetProductCategoryById(Guid theProductCategoryId)
    {
        var aProductCategory = await _theApplicationDbContext.ProductCategory.Where(x => x.Id == theProductCategoryId)
            .FirstOrDefaultAsync();
        return aProductCategory;
    }

    public async Task<List<ProductCategory>> GetAllProductCategory()
    {
        var aProductCategoryList = await _theApplicationDbContext.ProductCategory.ToListAsync();
        return aProductCategoryList;
    }

    public async Task UpdateProductCategory(ProductCategory theProductCategory)
    {
        _theApplicationDbContext.Update(theProductCategory);
        await _theApplicationDbContext.SaveChangesAsync();
    }

    public async Task RemoveProductCategory(ProductCategory theProductCategory)
    {
        _theApplicationDbContext.Remove(theProductCategory);
        await _theApplicationDbContext.SaveChangesAsync();
    }
}