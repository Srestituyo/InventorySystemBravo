using AutoMapper;
using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using InventorySystemBravo.Service.DTO;
using InventorySystemBravo.Service.Interface;
using InventorySystemBravo.Service.Model;
using InventorySystemBravo.Service.ViewModel;
using InventorySystemBravo.Service.Wrapper;

namespace InventorySystemBravo.Service.Service;

public class BrandCatalogService : IBrandCatalogService
{
    private readonly IBrandCatalogRepository _theBrandCatalogRepository;
    private readonly IMapper _theMapper;
    public BrandCatalogService(IBrandCatalogRepository theBrandCatalogRepository, IMapper theMapper)
    {
        _theBrandCatalogRepository = theBrandCatalogRepository;
        _theMapper = theMapper;
    }

    public async Task<Response<Guid>> AddBrandCatalog(BrandCatalogDTO theBrandCatalog)
    {
        var aNewBrandCatalog = new BrandCatalog()
        {
            Name = theBrandCatalog.Name,
            Status = theBrandCatalog.Status
        };
        
        await _theBrandCatalogRepository.AddBrandCatalog(aNewBrandCatalog);
        return new Response<Guid>(aNewBrandCatalog.Id);
    }

    public async Task<Response<BrandCatalogModel>> GetBrandCatalogById(Guid theBrandCatalog)
    {
        var aBrandCatalog = await _theBrandCatalogRepository.GetBrandCatalogById(theBrandCatalog);
        var aResponse = _theMapper.Map<BrandCatalogModel>(aBrandCatalog);
        return new Response<BrandCatalogModel>(aResponse);
    }

    public async Task<Response<BrandCatalogViewModel>> GetAllBrandCatalog()
    {
        var aBrandCatalogEntityList = await _theBrandCatalogRepository.GetAllBrandCatalog();
        var aBrandCatalogList = new BrandCatalogViewModel(); 

        foreach (var aBrandCatalog in aBrandCatalogEntityList)
        {
            var aMappedBrand = _theMapper.Map<BrandCatalogModel>(aBrandCatalog);
            aBrandCatalogList.BrandCatalog.Add(aMappedBrand);
        } 
        return new Response<BrandCatalogViewModel>(aBrandCatalogList);
    }

    public async Task<Response<Guid>> UpdateBrandCatalog(Guid theBrandCatalogId, BrandCatalogDTO theBrandCatalog)
    {
        var aBrandCatalog = await _theBrandCatalogRepository.GetBrandCatalogById(theBrandCatalogId);
        if (aBrandCatalog == null)
        {
            throw new KeyNotFoundException($"The Brand Catalog with id {theBrandCatalogId} not found.");
        }

        aBrandCatalog.Name = theBrandCatalog.Name;
        aBrandCatalog.Status = theBrandCatalog.Status;
        
        await _theBrandCatalogRepository.UpdateBrandCatalog(aBrandCatalog);
        return new Response<Guid>(aBrandCatalog.Id);
    } 

    public async Task<Response<Guid>> RemoveBrandCatalog(Guid theBrandCatalogId)
    {
        var aBrandCatalog = await _theBrandCatalogRepository.GetBrandCatalogById(theBrandCatalogId);

        if (aBrandCatalog == null)
        {
            throw new KeyNotFoundException($"The Brand Catalog with id {theBrandCatalogId} not found");
        }

        await _theBrandCatalogRepository.RemoveBrandCatalog(aBrandCatalog);
        return new Response<Guid>(aBrandCatalog.Id);
    }
}