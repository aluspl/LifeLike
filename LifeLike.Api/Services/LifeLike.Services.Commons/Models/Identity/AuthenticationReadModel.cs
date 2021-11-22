#region Usings

using System;

#endregion

namespace LifeLike.Services.Commons.Models.Identity
{
    public class AuthenticationReadModel
    {
        public string RefreshToken { get; set; }

        public string Token { get; set; }

        public Guid? Id { get; set; }
    }
}
