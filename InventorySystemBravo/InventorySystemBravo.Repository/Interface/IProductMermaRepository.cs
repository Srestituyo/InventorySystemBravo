using InventorySystemBravo.Domain.Entities;

namespace InventorySystemBravo.Repository.Interface;

public interface IProductMermaRepository
{
    Task<ProductMerma> GetProductMermaById(Guid theProductMermaId);

    Task<List<ProductMerma>> GetAllProductMerma();

    Task UpdateProductMerma(ProductMerma theProductMerma);

    Task RemoveProductMerma(ProductMerma theProductMerma);
}