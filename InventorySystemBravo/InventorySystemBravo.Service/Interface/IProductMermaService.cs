using InventorySystemBravo.Domain.Entities;

namespace InventorySystemBravo.Service.Interface;

public interface IProductMermaService
{
    Task AddProductMerma(ProductMerma theProductMerma);
    
    Task<ProductMerma> GetProductMermaById(Guid theProductMermaId);

    Task<List<ProductMerma>> GetAllProductMerma();

    Task UpdateProductMerma(ProductMerma theProductMerma);

    Task RemoveProductMerma(ProductMerma theProductMerma);
}