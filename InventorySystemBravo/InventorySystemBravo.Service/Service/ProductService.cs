using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using InventorySystemBravo.Service.Interface;

namespace InventorySystemBravo.Service.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _theProductRepository;

    public ProductService(IProductRepository theProductRepository)
    {
        _theProductRepository = theProductRepository;
    }

    public async Task AddProduct(Product theProduct)
    {
        await _theProductRepository.AddProduct(theProduct);
    }

    public async Task<Product> GetProductById(Guid theProductId)
    {
        var aProduct = await _theProductRepository.GetProductById(theProductId);
        return aProduct;
    }

    public async Task<List<Product>> GetAllProduct()
    {
        var aProductList = await _theProductRepository.GetAllProduct();
        return aProductList;
    }

    public async Task UpdateProduct(Product theProduct)
    {
        await _theProductRepository.UpdateProduct(theProduct);
    }

    public async Task RemoveProduct(Product theProduct)
    {
        await _theProductRepository.RemoveProduct(theProduct);
    }
}