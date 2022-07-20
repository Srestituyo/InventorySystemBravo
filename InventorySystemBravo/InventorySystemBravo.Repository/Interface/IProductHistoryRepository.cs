using InventorySystemBravo.Domain.Entities;

namespace InventorySystemBravo.Repository.Interface;

public interface IProductHistoryRepository
{
    Task AddProductHistory(ProductHistory theProductHistory);
    
    Task<ProductHistory> GetProductHistoryById(Guid theProductHistoryId);

    Task<List<ProductHistory>> GetAllProductHistory();

    Task UpdateProductHistory(ProductHistory theProductHistory);

    Task RemoveProductHistory(ProductHistory theProductHistory);
}