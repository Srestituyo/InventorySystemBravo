namespace InventorySystemBravo.Domain.Entities;

public class BrandCatalog : BaseEntity
{
    public string Name { get; set; }

    public bool Status { get; set; }

    public List<Product> Products { get; set; }

}