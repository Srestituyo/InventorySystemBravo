using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using InventorySystemBravo.Service.Interface;

namespace InventorySystemBravo.Service.Service;

public class ProductHistoryService : IProductHistoryService
{
    private readonly IProductHistoryRepository _theProductHistoryRepository;

    public ProductHistoryService(IProductHistoryRepository theProductHistoryRepository)
    {
        _theProductHistoryRepository = theProductHistoryRepository;
    }

    public async Task AddProductHistory(ProductHistory theProductHistory)
    {
        await _theProductHistoryRepository.AddProductHistory(theProductHistory);
    }

    public async Task<ProductHistory> GetProductHistoryById(Guid theProductHistoryId)
    {
        var aProductHistory = await _theProductHistoryRepository.GetProductHistoryById(theProductHistoryId);
        return aProductHistory;
    }

    public async Task<List<ProductHistory>> GetAllProductHistory()
    {
        var aProductHistory = await _theProductHistoryRepository.GetAllProductHistory();
        return aProductHistory;
    }

    public async Task UpdateProductHistory(ProductHistory theProductHistory)
    {
        await _theProductHistoryRepository.UpdateProductHistory(theProductHistory);
    }

    public async Task RemoveProductHistory(ProductHistory theProductHistory)
    {
        await _theProductHistoryRepository.RemoveProductHistory(theProductHistory);
    }
}