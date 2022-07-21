using AutoMapper;
using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.Common.Mapping;

namespace InventorySystemBravo.Service.Model;

public class ProductModel : IMapFrom<Product>
{
    public Guid Id { get; set; }
    
    public string ProductName { get; set; }

    public BrandCatalogModel BrandCatalog { get; set; }

    public float Price { get; set; }
    
    public int Quantity { get; set; }
    
    public int InShelf { get; set; }

    public DateTime DateOfEnty { get; set; }
    
    public DateTime ExpirationDate { get; set; }

    public string Condition { get; set; }

    public string UnitOfMeasure { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductModel>();
    }
}