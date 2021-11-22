#region Usings

using System;
using LifeLike.Database.Data.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

#endregion

namespace LifeLike.Database.Data.Stores
{
    public class PlatformUserRoleStore : RoleStore<RoleEntity, EFContext, Guid, UserRoleEntity, IdentityRoleClaim<Guid>>
    {
        public PlatformUserRoleStore(EFContext context)
            : base(context)
        {
        }
    }
}
