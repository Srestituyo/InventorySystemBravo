using InventorySystemBravo.Domain.Entities;
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
    public async Task<ProductMerma> GetProductMermaById(Guid theProductMermaId)
    {
        var aProductMerma = await _theProductMermaService.GetProductMermaById(theProductMermaId);
        return aProductMerma;
    }

    [HttpGet]
    public async Task<List<ProductMerma>> GetAllProductMerma()
    {
        var aProductMermaList = await _theProductMermaService.GetAllProductMerma();
        return aProductMermaList;
    }

    [HttpPost]
    public async Task AddProductMerma(ProductMerma theProductMerma)
    {
        await _theProductMermaService.AddProductMerma(theProductMerma);
    }
}