using AutoMapper;
using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.Common.Mapping;

namespace InventorySystemBravo.Service.Model;

public class ProductMermaModel : IMapFrom<ProductMerma>
{
    public Guid Id { get; set; }

    public string Reason { get; set; }
    
    public Guid CreatedBy { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProductMerma, ProductMermaModel>();
    }
}