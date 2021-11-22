#region Usings

using System;

#endregion

namespace LifeLike.Common.Config
{
    public class JWTConfig
    {
        public string Key { get; set; }

        public string Audience { get; set; }

        public TimeSpan TokenExpirationTime { get; set; }

        public string Issuer { get; set; }
    }
}