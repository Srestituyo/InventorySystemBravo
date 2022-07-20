using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventorySystemBravo.Repository.Repository;

public class ProductMermaRepository : IProductMermaRepository
{
    private readonly ApplicationDbContext _theApplicationDbContext;

    public ProductMermaRepository(ApplicationDbContext theApplicationDbContext)
    {
        _theApplicationDbContext = theApplicationDbContext;
    }

    public async Task<ProductMerma> GetProductMermaById(Guid theProductMermaId)
    {
        var aProductMerma = await _theApplicationDbContext.ProductMerma.Where(x => x.Id == theProductMermaId)
            .FirstOrDefaultAsync();
        return aProductMerma;
    }

    public async Task<List<ProductMerma>> GetAllProductMerma()
    {
        var aProductMermaList = await _theApplicationDbContext.ProductMerma.ToListAsync();
        return aProductMermaList;
    }

    public async Task UpdateProductMerma(ProductMerma theProductMerma)
    {
        _theApplicationDbContext.Update(theProductMerma);
        await _theApplicationDbContext.SaveChangesAsync();
    }

    public async Task RemoveProductMerma(ProductMerma theProductMerma)
    {
        _theApplicationDbContext.Remove(theProductMerma);
        await _theApplicationDbContext.SaveChangesAsync();
    }
}