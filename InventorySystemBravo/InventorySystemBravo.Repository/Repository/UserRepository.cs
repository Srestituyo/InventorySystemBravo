using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace InventorySystemBravo.Repository.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _theApplicationDbContext;

    public UserRepository(ApplicationDbContext theApplicationDbContext)
    {
        _theApplicationDbContext = theApplicationDbContext;
    }

    public async Task AddUser(User theUser)
    {
        await _theApplicationDbContext.Users.AddAsync(theUser);
        await _theApplicationDbContext.SaveChangesAsync();
    }

    public async Task<User> GetUserById(Guid theUserId)
    {
        var aUser = await _theApplicationDbContext.Users.Where(x => x.Id == theUserId).FirstOrDefaultAsync();
        return aUser;
    }

    public async Task<List<User>> GetAllUser()
    {
        var aUserList = await _theApplicationDbContext.Users.ToListAsync();
        return aUserList;
    }

    public async Task UpdateUser(User theUser)
    {
        _theApplicationDbContext.Update(theUser);
        await _theApplicationDbContext.SaveChangesAsync();
    }

    public async Task RemoveUser(User theUser)
    {
        _theApplicationDbContext.Remove(theUser);
        await _theApplicationDbContext.SaveChangesAsync();
    }
}