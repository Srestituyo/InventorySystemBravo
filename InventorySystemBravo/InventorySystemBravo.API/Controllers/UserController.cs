using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystemBravo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserService _theUserService;

    public UserController(IUserService theUserService)
    {
        _theUserService = theUserService;
    }

    [HttpGet("{theUserId}")]
    public async Task<User> GetUserById(Guid theUserId)
    {
        var aUser = await _theUserService.GetUserById(theUserId);
        return aUser;
    }

    [HttpGet]
    public async Task<List<User>> GetAllUser()
    {
        var aUserList = await _theUserService.GetAllUser();
        return aUserList;
    }

    [HttpPost]
    public async Task AddUser(User theUser)
    {
        await _theUserService.AddUser(theUser);
    }

    [HttpPut]
    public async Task UpdateUser(User theUser)
    {
        await _theUserService.UpdateUser(theUser);
    }
    
    [HttpDelete]
    public async Task RemoveUser(User theUser)
    {
        await _theUserService.RemoveUser(theUser);
    }
}