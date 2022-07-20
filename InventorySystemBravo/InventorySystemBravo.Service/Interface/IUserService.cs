using InventorySystemBravo.Domain.Entities;

namespace InventorySystemBravo.Service.Interface;

public interface IUserService
{
    Task AddUser(User theUser);
    
    Task<User> GetUserById(Guid theUserId);

    Task<List<User>> GetAllUser();

    Task UpdateUser(User theUser);

    Task RemoveUser(User theUser);
}