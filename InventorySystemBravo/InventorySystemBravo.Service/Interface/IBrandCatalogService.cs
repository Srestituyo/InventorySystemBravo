using InventorySystemBravo.Domain.Entities;

namespace InventorySystemBravo.Service.Interface;

public interface IBrandCatalogService
{
    Task AddBrandCatalog(BrandCatalog theBrandCatalog);
    
    Task<BrandCatalog> GetBrandCatalogById(Guid theBrandCatalog);

    Task<List<BrandCatalog>> GetAllBrandCatalog();

    Task UpdateBrandCatalog(BrandCatalog theBrandCatalog);

    Task RemoveBrandCatalog(BrandCatalog theBrandCatalog);
}