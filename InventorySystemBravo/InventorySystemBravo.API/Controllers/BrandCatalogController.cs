using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.DTO;
using InventorySystemBravo.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystemBravo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BrandCatalogController : ControllerBase
{
    private readonly IBrandCatalogService _theBrandCatalogService;

    public BrandCatalogController(IBrandCatalogService theBrandCatalogService)
    {
        _theBrandCatalogService = theBrandCatalogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBrandCatalog()
    {
        var aBrandCatalogList = await _theBrandCatalogService.GetAllBrandCatalog();
        return Ok(aBrandCatalogList);
    }

    [HttpGet("{theBrandCatalogId}")]
    public async Task<IActionResult> GetBrandCatalogById(Guid theBrandCatalogId)
    {
        var aBrandCatalog = await _theBrandCatalogService.GetBrandCatalogById(theBrandCatalogId);
        return Ok(aBrandCatalog);
    }

    [HttpPost]
    public async Task<IActionResult> AddBrandCatalog(BrandCatalogDTO theBrandCatalog)
    {
       var  aResult =   await _theBrandCatalogService.AddBrandCatalog(theBrandCatalog);
       return Ok(aResult);
    }

    [HttpPut("{theBrandCatalogId}")]
    public async Task<IActionResult> UpdateBrandCatalog(Guid theBrandCatalogId, BrandCatalogDTO theBrandCatalog)
    {
        var aResult = await _theBrandCatalogService.UpdateBrandCatalog(theBrandCatalogId, theBrandCatalog);
        return Ok(aResult);
    }

    [HttpDelete("{theBrandCatalogId}")]
    public async Task<IActionResult> RemoveBrandCatalog(Guid theBrandCatalogId)
    {
        var aResult  = await _theBrandCatalogService.RemoveBrandCatalog(theBrandCatalogId);
        return Ok(aResult);
    }
}