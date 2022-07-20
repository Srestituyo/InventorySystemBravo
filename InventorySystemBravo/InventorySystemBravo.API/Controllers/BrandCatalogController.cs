using InventorySystemBravo.Domain.Entities;
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
    public async Task<List<BrandCatalog>> GetAllBrandCatalog()
    {
        var aBrandCatalogList = await _theBrandCatalogService.GetAllBrandCatalog();
        return aBrandCatalogList;
    }

    [HttpGet("{theBrandCatalogId}")]
    public async Task<BrandCatalog> GetBrandCatalogById(Guid theBrandCatalogId)
    {
        var aBrandCatalog = await _theBrandCatalogService.GetBrandCatalogById(theBrandCatalogId);
        return aBrandCatalog;
    }

    [HttpPost]
    public async Task AddBrandCatalog(BrandCatalog theBrandCatalog)
    {
        await _theBrandCatalogService.AddBrandCatalog(theBrandCatalog);
    }

    [HttpPut]
    public async Task UpdateBrandCatalog(BrandCatalog theBrandCatalog)
    {
        await _theBrandCatalogService.UpdateBrandCatalog(theBrandCatalog);
    }

    [HttpDelete]
    public async Task RemoveBrandCatalog(BrandCatalog theBrandCatalog)
    {
        await _theBrandCatalogService.RemoveBrandCatalog(theBrandCatalog);
    }
}