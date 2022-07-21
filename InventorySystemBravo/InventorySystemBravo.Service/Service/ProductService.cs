using AutoMapper;
using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using InventorySystemBravo.Service.DTO;
using InventorySystemBravo.Service.Interface;
using InventorySystemBravo.Service.Model;
using InventorySystemBravo.Service.ViewModel;
using InventorySystemBravo.Service.Wrapper;

namespace InventorySystemBravo.Service.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _theProductRepository;
    private readonly IBrandCatalogService _theBrandCatalogService;
    private readonly IMapper _theMapper; 

    public ProductService(IProductRepository theProductRepository, IMapper theMapper, IBrandCatalogService theBrandCatalogService)
    {
        _theProductRepository = theProductRepository;
        _theMapper = theMapper;
        _theBrandCatalogService = theBrandCatalogService;
    }

    public async Task<Response<Guid>> AddProduct(ProductDTO theProduct)
    {
        var aBrandCatalog = await _theBrandCatalogService.GetBrandCatalogById(theProduct.BrandId);

        if (aBrandCatalog == null)
        {
            throw new KeyNotFoundException($"The brand catalog with id {theProduct.BrandId} was not found");
        }

        var aNewProduct = new Product()
        {
            ProductName = theProduct.ProductName,
            BrandId = theProduct.BrandId,
            Price = theProduct.Price,
            Quantity = theProduct.Quantity,
            InShelf = theProduct.InShelf,
            DateOfEnty = theProduct.DateOfEntry,
            ExpirationDate = theProduct.ExpirationDate,
            Condition = theProduct.Condition,
            UnitOfMeasure = theProduct.UnitOfMeasure
        };
        await _theProductRepository.AddProduct(aNewProduct);
        return new Response<Guid>(aNewProduct.Id);
    }

    public async Task<Response<ProductModel>> GetProductById(Guid theProductId)
    {
        var aProduct = await _theProductRepository.GetProductById(theProductId);
        var aResponse = _theMapper.Map<ProductModel>(aProduct);

        return new Response<ProductModel>(aResponse);
    }

    public async Task<Response<ProductViewModel>> GetAllProduct()
    {
        var aProductList = await _theProductRepository.GetAllProduct();

        var aProductViewModel = new ProductViewModel();

        foreach (var aProductItem in aProductList)
        {
            var aMappedProduct = _theMapper.Map<ProductModel>(aProductItem);
            aProductViewModel.Product.Add(aMappedProduct); 
        }
        return new  Response<ProductViewModel>(aProductViewModel);
    }

    public async Task<Response<Guid>> UpdateProduct(Guid theProductId, ProductDTO theProduct)
    {
        var aProduct = await _theProductRepository.GetProductById(theProductId);

        if (aProduct == null)
        {
            throw new KeyNotFoundException($"The product with id {theProductId} was not found.");
        }

        var aBrandCatalog = await _theBrandCatalogService.GetBrandCatalogById(theProduct.BrandId);

        if (aBrandCatalog == null)
        {
            throw new KeyNotFoundException($"The brand catalog with id {theProduct.BrandId} was not found");
        }

        aProduct.ProductName = theProduct.ProductName;
        aProduct.BrandId = theProduct.BrandId;
        aProduct.Price = theProduct.Price;
        aProduct.Quantity = theProduct.Quantity;
        aProduct.InShelf = theProduct.InShelf;
        aProduct.DateOfEnty = theProduct.DateOfEntry;
        aProduct.ExpirationDate = theProduct.ExpirationDate;
        aProduct.Condition = theProduct.Condition;
        aProduct.UnitOfMeasure = theProduct.UnitOfMeasure;

        await _theProductRepository.UpdateProduct(aProduct);
        return new Response<Guid>(aProduct.Id);
    }

    public async Task<Response<Guid>> RemoveProduct(Guid theProductId)
    {
        var aProduct = await _theProductRepository.GetProductById(theProductId);

        if (aProduct == null)
        {
            throw new KeyNotFoundException($"The product with id {theProductId} was not found.");
        }

        await _theProductRepository.RemoveProduct(aProduct);
        return new Response<Guid>(aProduct.Id);
    }
}