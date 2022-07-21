using AutoMapper;
using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using InventorySystemBravo.Service.DTO;
using InventorySystemBravo.Service.Interface;
using InventorySystemBravo.Service.Model;
using InventorySystemBravo.Service.ViewModel;
using InventorySystemBravo.Service.Wrapper;

namespace InventorySystemBravo.Service.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _theUserRepository;
    private readonly IMapper _theMapper;
    
    public UserService(IUserRepository theUserRepository, IMapper theMapper)
    {
        _theUserRepository = theUserRepository;
        _theMapper = theMapper;
    }

    public async Task<Response<Guid>> AddUser(UserDTO theUser)
    {
        var aNewUser = new User()
        {
            Name = theUser.Name,
            LastName = theUser.LastName,
            UserName = theUser.UserName
        };
        
        await _theUserRepository.AddUser(aNewUser);
        return new Response<Guid>(aNewUser.Id);
    }

    public async Task<Response<UserModel>> GetUserById(Guid theUserId)
    {
        var aUser = await _theUserRepository.GetUserById(theUserId);
        var aResponse = _theMapper.Map<UserModel>(aUser);
        return new Response<UserModel>(aResponse);
    }

    public async Task<Response<UserViewModel>> GetAllUser()
    {
        var aUserList = await _theUserRepository.GetAllUser();
        var aUserViewModel = new UserViewModel();

        foreach (var aUserItem in aUserList)
        {
            var aMappedUser = _theMapper.Map<UserModel>(aUserItem);
            aUserViewModel.Users.Add(aMappedUser); 
        }
        return new Response<UserViewModel>(aUserViewModel);
    }

    public async Task<Response<Guid>> UpdateUser(Guid theUserId, UserDTO theUser)
    {
        var aUser = await _theUserRepository.GetUserById(theUserId);
        
        if (aUser == null)
        {
            throw new KeyNotFoundException($"The user with id {theUserId} was not found");
        }

        aUser.Name = theUser.Name;
        aUser.LastName = theUser.LastName;
        aUser.UserName = theUser.UserName;
        
        await _theUserRepository.UpdateUser(aUser);
        return new Response<Guid>(aUser.Id);
    }

    public async Task<Response<Guid>> RemoveUser(Guid theUserId)
    {
        var aUser = await _theUserRepository.GetUserById(theUserId);

        if (aUser == null)
        {
            throw new KeyNotFoundException($"The user with id {theUserId} was not found.");
        }

        await _theUserRepository.RemoveUser(aUser);
        return new Response<Guid>(aUser.Id);
    }
}