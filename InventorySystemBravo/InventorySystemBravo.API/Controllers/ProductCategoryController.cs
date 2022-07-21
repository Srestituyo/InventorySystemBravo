using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.DTO;
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
    public async Task<IActionResult> GetProductCategoryById(Guid theProductCategoryId)
    {
        var aProduct = await _theProductCategoryService.GetProductCategoryById(theProductCategoryId);
        return Ok(aProduct);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProductCategory()
    {
        var aProductCategoryList = await _theProductCategoryService.GetAllProductCategory();
        return Ok(aProductCategoryList);
    }

    [HttpPost]
    public async Task<IActionResult> AddProductCategory(ProductCategoryDTO theProductCategory)
    {
        var aResult = await _theProductCategoryService.AddProductCategory(theProductCategory);
        return Ok(aResult);
    }

    [HttpPut("{theProductCategoryId}")]
    public async Task<IActionResult> UpdateProductCategory(Guid theProductCategoryId, ProductCategoryDTO theProductCategory)
    {
       var aResult =  await _theProductCategoryService.UpdateProductCategory(theProductCategoryId, theProductCategory);
       return Ok(aResult);
    }

    [HttpDelete("{theProductCategoryId}")]
    public async Task<IActionResult> RemoveProductCategory(Guid theProductCategoryId)
    {
       var aResult = await _theProductCategoryService.RemoveProductCategory(theProductCategoryId);
       return Ok(aResult);
    }
}