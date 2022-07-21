using AutoMapper;
using InventorySystemBravo.Domain.Entities;
using InventorySystemBravo.Service.Common.Mapping;

namespace InventorySystemBravo.Service.Model;

public class UserModel : IMapFrom<User>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserModel>();
    }
}