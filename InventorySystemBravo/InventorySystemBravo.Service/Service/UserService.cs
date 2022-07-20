using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using InventorySystemBravo.Service.Interface;

namespace InventorySystemBravo.Service.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _theUserRepository;

    public UserService(IUserRepository theUserRepository)
    {
        _theUserRepository = theUserRepository;
    }

    public async Task AddUser(User theUser)
    {
        await _theUserRepository.AddUser(theUser);
    }

    public async Task<User> GetUserById(Guid theUserId)
    {
        var aUser = await _theUserRepository.GetUserById(theUserId);
        return aUser;
    }

    public async Task<List<User>> GetAllUser()
    {
        var aUserList = await _theUserRepository.GetAllUser();
        return aUserList;
    }

    public async Task UpdateUser(User theUser)
    {
        await _theUserRepository.UpdateUser(theUser);
    }

    public async Task RemoveUser(User theUser)
    {
        await _theUserRepository.RemoveUser(theUser);
    }
}