namespace InventorySystemBravo.Service.DTO;

public class ProductMermaDTO
{
    public Guid ProductId { get; set; }

    public string Reason { get; set; }

    public Guid CreatedBy { get; set; }
}