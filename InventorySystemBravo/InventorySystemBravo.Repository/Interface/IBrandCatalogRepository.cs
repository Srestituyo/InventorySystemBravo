using InventorySystemBravo.Domain.Entities;

namespace InventorySystemBravo.Repository.Interface;

public interface IBrandCatalogRepository
{
    Task AddBrandCatalog(BrandCatalog theBrandCatalog);
    
    Task<BrandCatalog> GetBrandCatalogById(Guid theBrandCatalog);

    Task<List<BrandCatalog>> GetAllBrandCatalog();

    Task UpdateBrandCatalog(BrandCatalog theBrandCatalog);

    Task RemoveBrandCatalog(BrandCatalog theBrandCatalog);
}