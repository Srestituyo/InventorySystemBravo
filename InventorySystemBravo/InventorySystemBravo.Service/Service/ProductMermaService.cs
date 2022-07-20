using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using InventorySystemBravo.Service.Interface;

namespace InventorySystemBravo.Service.Service;

public class ProductMermaService : IProductMermaService
{
    private readonly IProductMermaRepository _theProductMermaRepository;

    public ProductMermaService(IProductMermaRepository theProductMermaRepository)
    {
        _theProductMermaRepository = theProductMermaRepository;
    }

    public async Task AddProductMerma(ProductMerma theProductMerma)
    {
        await _theProductMermaRepository.AddProductMerma(theProductMerma);
    }

    public async Task<ProductMerma> GetProductMermaById(Guid theProductMermaId)
    {
        var aProductMerma = await _theProductMermaRepository.GetProductMermaById(theProductMermaId);
        return aProductMerma;
    }

    public async Task<List<ProductMerma>> GetAllProductMerma()
    {
        var aProductMermaList = await _theProductMermaRepository.GetAllProductMerma();
        return aProductMermaList;
    }

    public async Task UpdateProductMerma(ProductMerma theProductMerma)
    {
        await _theProductMermaRepository.UpdateProductMerma(theProductMerma);
    }

    public async Task RemoveProductMerma(ProductMerma theProductMerma)
    {
        await _theProductMermaRepository.RemoveProductMerma(theProductMerma);
    }
}