namespace InventorySystemBravo.Service.DTO;

public class ProductDTO
{
    public string ProductName { get; set; }

    public Guid BrandId { get; set; }

    public float Price { get; set; }

    public int Quantity { get; set; }

    public int InShelf { get; set; }

    public DateTime DateOfEntry { get; set; }

    public DateTime ExpirationDate { get; set; }

    public string Condition { get; set; }

    public string UnitOfMeasure { get; set; }
    
}