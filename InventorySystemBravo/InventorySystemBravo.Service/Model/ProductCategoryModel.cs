using AutoMapper;
using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.Common.Mapping;

namespace InventorySystemBravo.Service.Model;

public class ProductCategoryModel :  IMapFrom<ProductCategory>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProductCategory, ProductCategoryModel>();
    }
}