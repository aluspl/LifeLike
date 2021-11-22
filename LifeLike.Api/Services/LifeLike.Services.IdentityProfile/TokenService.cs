#region Usings

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using LifeLike.Common.Config;
using LifeLike.Common.Const;
using LifeLike.Common.Enums;
using LifeLike.Common.Exceptions;
using LifeLike.Common.Extensions;
using LifeLike.Common.Helpers;
using LifeLike.Database.Data.Entities.User;
using LifeLike.Services.Commons.Interfaces.Identity;
using LifeLike.Services.Commons.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

#endregion

namespace Lifelike.Services.IdentityService
{
    public class TokenService : ITokenService
    {
        private readonly JWTConfig AuthConfig;

        #region Lazy Providers

        private readonly UserManager<UserEntity> UserManager;
        private readonly IRefreshTokenGeneratorService RefreshTokenGeneratorService;

        #endregion

        #region Constructor(s)

        public TokenService(
            UserManager<UserEntity> userManager,
            IRefreshTokenGeneratorService refreshTokenGeneratorService,
            IOptions<JWTConfig> authOptions)
        {
            AuthConfig = authOptions.Value;

            UserManager = userManager;
            RefreshTokenGeneratorService = refreshTokenGeneratorService;
        }

        #endregion

        #region Properties

        #endregion

        public async Task<AuthenticationReadModel> GenerateUserTokensAsync(UserEntity userEntity)
        {
            var jwtToken = await GenerateJwtToken(userEntity);
            var refreshToken = RefreshTokenGeneratorService.GenerateRefreshToken();

            userEntity.RefreshTokens.Add(new RefreshTokenEntity(refreshToken));

            await UserManager.UpdateAsync(userEntity).ThrowIfFailed();

            return new AuthenticationReadModel
            {
                Token = "Bearer " + jwtToken,
                RefreshToken = refreshToken,
                Id = userEntity.Id,
            };
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            try
            {
                token = token.Replace("Bearer ", string.Empty);
                var tokenValidationParameters = TokenValidation.GetTokenValidation(AuthConfig);
                tokenValidationParameters.ValidateLifetime = false;
                var principal = new JwtSecurityTokenHandler().ValidateToken(
                    token,
                    tokenValidationParameters,
                    out var securityToken);

                return IsJwtWithValidSecurityAlgorithm(securityToken)
                    ? principal
                    : null;
            }
            catch (Exception)
            {
                throw new BusinessException(ErrorType.TokenInvalid.ToString());
            }
        }

        #region Private Methods

        private async Task<string> GenerateJwtToken(UserEntity userEntity)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = await GetUserClaims(userEntity);
            var jwtKey = TokenValidation.GetTokenKey(AuthConfig);
            var jwtToken = new JwtSecurityToken(
                AuthConfig.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.Add(AuthConfig.TokenExpirationTime),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(jwtKey), SecurityAlgorithms.HmacSha256Signature));

            return tokenHandler.WriteToken(jwtToken);
        }

        private async Task<List<Claim>> GetUserClaims(UserEntity userEntity)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtClaims.Email, userEntity.Email),
                new Claim(JwtClaims.Id, userEntity.Id.ToString()),
            };

            if (!string.IsNullOrWhiteSpace(userEntity.Firstname))
            {
                claims.Add(new Claim(JwtClaims.Name, userEntity.Firstname));
            }

            claims.AddRange(await UserManager.GetClaimsAsync(userEntity));

            return claims;
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken jwtToken)
        {
            return jwtToken is JwtSecurityToken jwtSecurityToken &&
                   jwtSecurityToken.Header.Alg.Equals(
                       SecurityAlgorithms.HmacSha256Signature,
                       StringComparison.InvariantCultureIgnoreCase);
        }

        #endregion
    }
}
