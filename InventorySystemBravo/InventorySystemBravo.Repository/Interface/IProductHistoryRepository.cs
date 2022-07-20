using InventorySystemBravo.Domain.Entities;

namespace InventorySystemBravo.Repository.Interface;

public interface IProductHistoryRepository
{
    Task<ProductHistory> GetProductHistoryById(Guid theProductHistoryId);

    Task<List<ProductHistory>> GetAllProductHistory();

    Task UpdateProductHistory(ProductHistory theProductHistory);

    Task RemoveProductHistory(ProductHistory theProductHistory);
}