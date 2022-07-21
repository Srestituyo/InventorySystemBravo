using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.DTO;
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
    public async Task<IActionResult> GetUserById(Guid theUserId)
    {
        var aUser = await _theUserService.GetUserById(theUserId);
        return Ok(aUser);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUser()
    {
        var aUserList = await _theUserService.GetAllUser();
        return Ok(aUserList);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(UserDTO theUser)
    {
        var aResult = await _theUserService.AddUser(theUser);
        return Ok(aResult);
    }

    [HttpPut("{theUserId}")]
    public async Task<IActionResult> UpdateUser(Guid theUserId, UserDTO theUser)
    {
        var aResult = await _theUserService.UpdateUser(theUserId, theUser);
        return Ok(aResult);
    }
    
    [HttpDelete("{theUserId}")]
    public async Task<IActionResult> RemoveUser(Guid theUserId)
    {
        var aResult = await _theUserService.RemoveUser(theUserId);
        return Ok(aResult);
    }
}