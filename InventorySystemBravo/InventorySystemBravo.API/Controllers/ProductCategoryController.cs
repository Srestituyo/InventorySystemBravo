using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystemBravo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductCategoryController : ControllerBase
{
    private readonly IProductCategoryService _theProductCategoryService;

    public ProductCategoryController(IProductCategoryService theProductCategoryService)
    {
        _theProductCategoryService = theProductCategoryService;
    }

    [HttpGet("{theProductCategoryId}")]
    public async Task<ProductCategory> GetProductCategoryById(Guid theProductCategoryId)
    {
        var aProduct = await _theProductCategoryService.GetProductCategoryById(theProductCategoryId);
        return aProduct;
    }

    [HttpGet]
    public async Task<List<ProductCategory>> GetAllProductCategory()
    {
        var aProductCategoryList = await _theProductCategoryService.GetAllProductCategory();
        return aProductCategoryList;
    }

    [HttpPost]
    public async Task AddProductCategory(ProductCategory theProductCategory)
    {
        await _theProductCategoryService.AddProductCategory(theProductCategory);
    }

    [HttpPut]
    public async Task UpdateProductCategory(ProductCategory theProductCategory)
    {
        await _theProductCategoryService.UpdateProductCategory(theProductCategory);
    }

    [HttpDelete]
    public async Task RemoveProductCategory(ProductCategory theProductCategory)
    {
        await _theProductCategoryService.RemoveProductCategory(theProductCategory);
    }
}