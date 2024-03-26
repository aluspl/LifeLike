using LifeLike.Database.Data.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace LifeLike.Database.Data.Entities.User;

public class UserEntity : IdentityUser, IBaseEntity
{
    public Guid Id { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }
}