using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using InventorySystemBravo.Service.Interface;

namespace InventorySystemBravo.Service.Service;

public class BrandCatalogService : IBrandCatalogService
{
    private readonly IBrandCatalogRepository _theBrandCatalogRepository;

    public BrandCatalogService(IBrandCatalogRepository theBrandCatalogRepository)
    {
        _theBrandCatalogRepository = theBrandCatalogRepository;
    }

    public async Task AddBrandCatalog(BrandCatalog theBrandCatalog)
    {
        await _theBrandCatalogRepository.AddBrandCatalog(theBrandCatalog);
    }

    public async Task<BrandCatalog> GetBrandCatalogById(Guid theBrandCatalog)
    {
        var aBrandCatalog = await _theBrandCatalogRepository.GetBrandCatalogById(theBrandCatalog);
        return aBrandCatalog;
    }

    public async Task<List<BrandCatalog>> GetAllBrandCatalog()
    {
        var aBrandCatalogList = await _theBrandCatalogRepository.GetAllBrandCatalog();
        return aBrandCatalogList;
    }

    public async Task UpdateBrandCatalog(BrandCatalog theBrandCatalog)
    {
        await _theBrandCatalogRepository.UpdateBrandCatalog(theBrandCatalog);
    }

    public async Task RemoveBrandCatalog(BrandCatalog theBrandCatalog)
    {
        await _theBrandCatalogRepository.RemoveBrandCatalog(theBrandCatalog);
    }
}