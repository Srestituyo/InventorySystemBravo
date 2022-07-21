using InventorySystemBravo.Service.Model;

namespace InventorySystemBravo.Service.ViewModel;

public class ProductHistoryViewModel
{
    public List<ProductHistoryModel> ProductHistory { get; set; } = new List<ProductHistoryModel>();
}