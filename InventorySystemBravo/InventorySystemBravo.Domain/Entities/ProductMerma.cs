namespace InventorySystemBravo.Domain.Entities;

public class ProductMerma : BaseEntity
{ 
    public Guid ProductId {get; set; }

    public virtual Product Product { get; set; }

    public string Reason { get; set; }

    public Guid CreatedBy { get; set; }
    
}