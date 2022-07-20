using InventorySystemBravo.Domain.Entities;
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
    public async Task<Product> GetProductById(Guid theProductId)
    {
        var aProduct = await _theProductService.GetProductById(theProductId);
        return aProduct;
    }

    [HttpGet]
    public async Task<List<Product>> GetAllProduct()
    {
        var aProductList = await _theProductService.GetAllProduct();
        return aProductList;
    }

    [HttpPost]
    public async Task AddProduct(Product theProduct)
    {
        await _theProductService.AddProduct(theProduct);
    }

    [HttpPut]
    public async Task UpdateProduct(Product theProduct)
    {
        await _theProductService.UpdateProduct(theProduct);
    }

    [HttpDelete]
    public async Task RemoveProduct(Product theProduct)
    {
        await _theProductService.RemoveProduct(theProduct);
    }
}