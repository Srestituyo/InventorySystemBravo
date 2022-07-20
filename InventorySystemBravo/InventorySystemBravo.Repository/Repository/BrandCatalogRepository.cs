using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventorySystemBravo.Repository.Repository;

public class BrandCatalogRepository : IBrandCatalogRepository
{
    private readonly ApplicationDbContext _theApplicationDbContext;

    public BrandCatalogRepository(ApplicationDbContext theApplicationDbContext)
    {
        _theApplicationDbContext = theApplicationDbContext;
    }

    public async Task<BrandCatalog> GetBrandCatalogById(Guid theBrandCatalog)
    {
        var aBrandCatalog = await _theApplicationDbContext.BrandCatalogs.Where(x => x.Id == theBrandCatalog).FirstOrDefaultAsync();
        return aBrandCatalog;
    }

    public async Task<List<BrandCatalog>> GetAllBrandCatalog()
    {
        var aBrandCatalogList = await _theApplicationDbContext.BrandCatalogs.ToListAsync();
        return aBrandCatalogList;
    }

    public async Task UpdateBrandCatalog(BrandCatalog theBrandCatalog)
    {
        _theApplicationDbContext.Update(theBrandCatalog);
        await _theApplicationDbContext.SaveChangesAsync();
    }

    public async Task RemoveBrandCatalog(BrandCatalog theBrandCatalog)
    {
        _theApplicationDbContext.Remove(theBrandCatalog);
        await _theApplicationDbContext.SaveChangesAsync();
    }
}