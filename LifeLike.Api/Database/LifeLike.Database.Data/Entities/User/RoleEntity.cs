#region Usings

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

#endregion

namespace LifeLike.Database.Data.Entities.User
{
    public class RoleEntity : IdentityRole<Guid>
    {
        public virtual ICollection<UserRoleEntity> Users { get; set; }
    }
}
