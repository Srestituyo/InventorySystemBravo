using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.DTO;
using InventorySystemBravo.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystemBravo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _theProductService;

    public ProductController(IProductService theProductService)
    {
        _theProductService = theProductService;
    }

    [HttpGet("{theProductId}")]
    public async Task<IActionResult> GetProductById(Guid theProductId)
    {
        var aProduct = await _theProductService.GetProductById(theProductId);
        return Ok(aProduct);
    }

    [HttpGet]
    public async Task<IActionResult>  GetAllProduct()
    {
        var aProductList = await _theProductService.GetAllProduct();
        return Ok(aProductList);
    }

    [HttpPost]
    public async Task<IActionResult>  AddProduct(ProductDTO theProduct)
    {
       var aResult =  await _theProductService.AddProduct(theProduct);
       return Ok(aResult);
    }

    [HttpPut("{theProductId}")]
    public async Task<IActionResult>  UpdateProduct(Guid theProductId, ProductDTO theProduct)
    {
        var aResult = await _theProductService.UpdateProduct(theProductId, theProduct);
        return Ok(aResult);
    }

    [HttpDelete("{theProductId}")]
    public async Task<IActionResult>  RemoveProduct(Guid theProductId)
    {
        var aResult = await _theProductService.RemoveProduct(theProductId);
        return Ok(aResult);
    }
}