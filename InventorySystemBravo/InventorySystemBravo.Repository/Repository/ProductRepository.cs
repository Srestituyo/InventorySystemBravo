using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventorySystemBravo.Repository.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _theApplicationDbContext;

    public ProductRepository(ApplicationDbContext theApplicationDbContext)
    {
        _theApplicationDbContext = theApplicationDbContext;
    }

    public async Task AddProduct(Product theProduct)
    {
        await _theApplicationDbContext.Products.AddAsync(theProduct);
        await _theApplicationDbContext.SaveChangesAsync();
    }

    public async Task<Product> GetProductById(Guid theProductId)
    {
        var aProduct = await _theApplicationDbContext.Products.Where(x => x.Id == theProductId).FirstOrDefaultAsync();
        return aProduct;
    }

    public async Task<List<Product>> GetAllProduct()
    {
        var aProductList = await _theApplicationDbContext.Products.ToListAsync();
        return aProductList;
    }

    public async Task UpdateProduct(Product theProduct)
    {
        _theApplicationDbContext.Update(theProduct);
        await _theApplicationDbContext.SaveChangesAsync();
    }

    public async Task RemoveProduct(Product theProduct)
    {
        _theApplicationDbContext.Remove(theProduct);
        await _theApplicationDbContext.SaveChangesAsync();
    }
}