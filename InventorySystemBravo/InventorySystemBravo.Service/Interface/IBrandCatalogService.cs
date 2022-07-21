using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.DTO;
using InventorySystemBravo.Service.Model;
using InventorySystemBravo.Service.ViewModel;
using InventorySystemBravo.Service.Wrapper;

namespace InventorySystemBravo.Service.Interface;

public interface IBrandCatalogService
{
    Task<Response<Guid>> AddBrandCatalog(BrandCatalogDTO theBrandCatalog);
    
    Task<Response<BrandCatalogModel>> GetBrandCatalogById(Guid theBrandCatalog);

    Task<Response<BrandCatalogViewModel>> GetAllBrandCatalog();

    Task<Response<Guid>> UpdateBrandCatalog(Guid theBrandCatalogId, BrandCatalogDTO theBrandCatalog);

    Task<Response<Guid>> RemoveBrandCatalog(Guid theBranCatalogId);
}