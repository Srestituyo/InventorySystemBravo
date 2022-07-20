namespace InventorySystemBravo.Domain.Entities;

public class ProductHistory : BaseEntity
{ 
    public Guid ProductId { get; set; }

    public virtual Product Product { get; set; }

    public string Action { get; set; }
}