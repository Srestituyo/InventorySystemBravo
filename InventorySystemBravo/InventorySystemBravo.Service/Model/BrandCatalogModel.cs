using AutoMapper;
using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.Common.Mapping;

namespace InventorySystemBravo.Service.Model;

public class BrandCatalogModel  :  IMapFrom<BrandCatalog>
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public bool Status { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<BrandCatalog, BrandCatalogModel>();
    }
}