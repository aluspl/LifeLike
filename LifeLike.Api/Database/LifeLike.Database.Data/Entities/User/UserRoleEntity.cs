#region Usings

using System;
using Microsoft.AspNetCore.Identity;

#endregion

namespace LifeLike.Database.Data.Entities.User
{
    public class UserRoleEntity : IdentityUserRole<Guid>
    {
        public virtual UserEntity User { get; set; }

        public virtual RoleEntity Role { get; set; }
    }
}
