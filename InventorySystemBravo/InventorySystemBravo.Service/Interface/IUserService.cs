using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.DTO;
using InventorySystemBravo.Service.Model;
using InventorySystemBravo.Service.ViewModel;
using InventorySystemBravo.Service.Wrapper;

namespace InventorySystemBravo.Service.Interface;

public interface IUserService
{
    Task<Response<Guid>> AddUser(UserDTO theUser);
    
    Task<Response<UserModel>> GetUserById(Guid theUserId);

    Task<Response<UserViewModel>> GetAllUser();

    Task<Response<Guid>> UpdateUser(Guid theUserId, UserDTO theUser);

    Task<Response<Guid>> RemoveUser(Guid theUserId);
}