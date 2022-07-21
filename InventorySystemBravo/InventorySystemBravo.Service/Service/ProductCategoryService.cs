using AutoMapper;
using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using InventorySystemBravo.Service.DTO;
using InventorySystemBravo.Service.Interface;
using InventorySystemBravo.Service.Model;
using InventorySystemBravo.Service.ViewModel;
using InventorySystemBravo.Service.Wrapper;

namespace InventorySystemBravo.Service.Service;

public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _theProductCategoryRepository;
    private readonly IMapper _theMapper;
    
    public ProductCategoryService(IProductCategoryRepository theProductCategoryRepository, IMapper theMapper)
    {
        _theProductCategoryRepository = theProductCategoryRepository;
        _theMapper = theMapper;
    }

    public async Task<Response<Guid>> AddProductCategory(ProductCategoryDTO theProductCategory)
    {
        var aNewProductCategory = new ProductCategory()
        {
            Name = theProductCategory.Name
        };
        
        await _theProductCategoryRepository.AddProductCategory(aNewProductCategory);
        return new Response<Guid>(aNewProductCategory.Id);
    }

    public async Task<Response<ProductCategoryModel>> GetProductCategoryById(Guid theProductCategoryId)
    {
        var aProductCategory = await _theProductCategoryRepository.GetProductCategoryById(theProductCategoryId);
        var aResponse = _theMapper.Map<ProductCategoryModel>(aProductCategory);
        return new  Response<ProductCategoryModel>(aResponse);
    }

    public async Task<Response<ProductCategoryViewModel>> GetAllProductCategory()
    {
        var aProductCategoryList = await _theProductCategoryRepository.GetAllProductCategory(); 

        var aProductCategoryViewModel = new ProductCategoryViewModel();

        foreach (var aProductCategoryItem in aProductCategoryList)
        { 
            var aMappedProductCategory = _theMapper.Map<ProductCategoryModel>(aProductCategoryItem);
            aProductCategoryViewModel.ProductCategory.Add(aMappedProductCategory); 
        }

        return new Response<ProductCategoryViewModel>(aProductCategoryViewModel);
    }

    public async Task<Response<Guid>> UpdateProductCategory(Guid theProductCategoryId, ProductCategoryDTO theProductCategory)
    {
        var aProductCategory = await _theProductCategoryRepository.GetProductCategoryById(theProductCategoryId);

        if (aProductCategory == null)
        {
            throw new KeyNotFoundException($"The product category with id {theProductCategoryId} was not found.");
        }

        aProductCategory.Name = theProductCategory.Name;

        await _theProductCategoryRepository.UpdateProductCategory(aProductCategory);
        return new Response<Guid>(aProductCategory.Id);
    }

    public async Task<Response<Guid>> RemoveProductCategory(Guid theProductCategoryId)
    {
        var aProductCategory = await _theProductCategoryRepository.GetProductCategoryById(theProductCategoryId);

        if (aProductCategory == null)
        {
            throw new KeyNotFoundException($"The product category with id {theProductCategoryId} was not found.");
        }

        await _theProductCategoryRepository.RemoveProductCategory(aProductCategory);
        return new Response<Guid>(aProductCategory.Id);
    }
}