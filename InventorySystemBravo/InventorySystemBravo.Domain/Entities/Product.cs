namespace InventorySystemBravo.Domain.Entities;

public class Product : BaseEntity
{
    public string ProductName { get; set; }

    public Guid BrandId { get; set;  }

    public BrandCatalog BrandCatalog { get; set; }

    public float Price { get; set; }

    public int Quantity { get; set; }

    public int InShelf { get; set; }

    public DateTime DateOfEnty { get; set; }

    public DateTime ExpirationDate { get; set; }

    public string Condition { get; set; }

    public string UnitOfMeasure { get; set; }

    public ProductMerma ProductMerma { get; set; }

    public List<ProductHistory> ProductHistory { get; set; }
}