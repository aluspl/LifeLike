#region Usings

using System;
using LifeLike.Database.Data.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

#endregion

namespace LifeLike.Database.Data.Stores
{
    public class PlatformUserStore : UserStore<UserEntity, RoleEntity, EFContext, Guid, IdentityUserClaim<Guid>, UserRoleEntity, IdentityUserLogin<Guid>, IdentityUserToken<Guid>, IdentityRoleClaim<Guid>>
    {
        public PlatformUserStore(EFContext context, IdentityErrorDescriber describer)
            : base(context, describer)
        {
        }
    }
}
