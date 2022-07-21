using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.DTO;
using InventorySystemBravo.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystemBravo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductMermaControlller : ControllerBase
{
    private readonly IProductMermaService _theProductMermaService;

    public ProductMermaControlller(IProductMermaService theProductMermaService)
    {
        _theProductMermaService = theProductMermaService;
    }
    
    [HttpGet("{theProductMermaId}")]
    public async Task<IActionResult> GetProductMermaById(Guid theProductMermaId)
    {
        var aProductMerma = await _theProductMermaService.GetProductMermaById(theProductMermaId);
        return Ok(aProductMerma);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProductMerma()
    {
        var aProductMermaList = await _theProductMermaService.GetAllProductMerma();
        return Ok(aProductMermaList);
    }

    [HttpPost]
    public async Task<IActionResult> AddProductMerma(ProductMermaDTO theProductMerma)
    {
        var aResult  = await _theProductMermaService.AddProductMerma(theProductMerma);
        return Ok(aResult);
    }
}