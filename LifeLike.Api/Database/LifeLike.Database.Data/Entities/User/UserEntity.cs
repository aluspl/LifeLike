using System;
using System.Collections.Generic;
using LifeLike.Database.Data.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace LifeLike.Database.Data.Entities.User
{
    public class UserEntity : IdentityUser<Guid>, IBaseEntity
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public ICollection<RefreshTokenEntity> RefreshTokens { get; set; }
    }
}
