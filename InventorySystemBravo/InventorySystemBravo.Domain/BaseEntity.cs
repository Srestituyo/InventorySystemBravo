namespace InventorySystemBravo.Domain;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime LastUpdatedDate { get; set; } = new DateTime();

    public DateTime CreatedDate { get; set; } = new DateTime();

    public Guid LastUpdatedBy { get; set; }
}