#region Usings

using System;
using System.Security.Cryptography;
using LifeLike.Services.Commons.Interfaces.Identity;

#endregion

namespace Lifelike.Services.IdentityService
{
    public class RandomRefreshTokenGeneratorService : IRefreshTokenGeneratorService
    {
        private const int RefreshTokenLength = 32;

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[RefreshTokenLength];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }
    }
}
