namespace InventorySystemBravo.Domain.Entities;

public class User : BaseEntity
{ 
    public string Name {get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }
}