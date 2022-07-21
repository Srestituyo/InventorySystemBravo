using InventorySystemBravo.Service.Model;

namespace InventorySystemBravo.Service.ViewModel;

public class UserViewModel
{
    public List<UserModel> Users { get; set; }  = new List<UserModel>();
}