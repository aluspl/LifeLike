#region Usings

using System.Text;
using LifeLike.Common.Config;
using Microsoft.IdentityModel.Tokens;

#endregion

namespace LifeLike.Common.Helpers;

public static class TokenValidation
{
    #region GetTokenValidator

    public static TokenValidationParameters GetTokenValidation(JWTConfig authConfig)
    {
        var key = new SymmetricSecurityKey(GetTokenKey(authConfig));

        var tokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = key,
            ValidIssuer = authConfig.Issuer,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            RequireExpirationTime = true,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
        };
        return tokenValidationParameters;
    }

    public static byte[] GetTokenKey(JWTConfig authConfig)
    {
        if (authConfig is null)
        {
            throw new ArgumentNullException(nameof(authConfig));
        }

        return Encoding.UTF8.GetBytes(authConfig.Key);
    }

    #endregion
}