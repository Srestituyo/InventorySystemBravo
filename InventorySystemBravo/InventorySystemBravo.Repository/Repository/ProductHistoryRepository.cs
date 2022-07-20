using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventorySystemBravo.Repository.Repository;

public class ProductHistoryRepository : IProductHistoryRepository
{
    private readonly ApplicationDbContext _theApplicationDbContext;

    public ProductHistoryRepository(ApplicationDbContext theApplicationDbContext)
    {
        _theApplicationDbContext = theApplicationDbContext;
    }

    public async Task<ProductHistory> GetProductHistoryById(Guid theProductHistoryId)
    {
        var aProductHistory = await _theApplicationDbContext.ProductHistory.Where(x => x.Id == theProductHistoryId)
            .FirstOrDefaultAsync();
        return aProductHistory;
    }

    public async Task<List<ProductHistory>> GetAllProductHistory()
    {
        var aProductHistoryList = await _theApplicationDbContext.ProductHistory.ToListAsync();
        return aProductHistoryList;
    }

    public async Task UpdateProductHistory(ProductHistory theProductHistory)
    {
        _theApplicationDbContext.Update(theProductHistory);
        await _theApplicationDbContext.SaveChangesAsync();
    }

    public async Task RemoveProductHistory(ProductHistory theProductHistory)
    {
        _theApplicationDbContext.Remove(theProductHistory);
        await _theApplicationDbContext.SaveChangesAsync();
    }
}