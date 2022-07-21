using AutoMapper;
using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.Common.Mapping;

namespace InventorySystemBravo.Service.Model;

public class ProductHistoryModel:  IMapFrom<ProductHistory>
{
    public Guid Id { get; set; }

    public string Action { get; set; }

    public DateTime CreatedDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProductHistory, ProductHistoryModel>();
    }
}