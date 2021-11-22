#region Usings

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LifeLike.Common.Config;
using LifeLike.Common.Enums;
using LifeLike.Common.Exceptions;
using LifeLike.Database.Data.Entities.User;
using LifeLike.Services.Commons.Interfaces.Identity;
using LifeLike.Services.Commons.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

#endregion

namespace Lifelike.Services.IdentityService
{
    public class UserIdentityService : IUserIdentityService
    {
        #region Private Members

        private readonly JWTConfig JwtConfig;

        private readonly byte[] JwtKey;

        private readonly IMapper Mapper;

        private readonly UserManager<UserEntity> UserManager;

        private readonly ILogger<UserIdentityService> Logger;

        private readonly ITokenService TokenService;

        #endregion

        public UserIdentityService(
            UserManager<UserEntity> userManagerProvider,
            IMapper mapperProvider,
            ILogger<UserIdentityService> loggerProvider,
            ITokenService tokenServiceProvider,
            IOptions<JWTConfig> authOptions)
        {
            JwtConfig = authOptions.Value;
            JwtKey = Encoding.ASCII.GetBytes(JwtConfig.Key);
            Logger = loggerProvider;
            TokenService = tokenServiceProvider;
            UserManager = userManagerProvider;
            Mapper = mapperProvider;
        }

        #region Properties

        #endregion

        #region Traditional Login

        public async Task<AuthenticationReadModel> LoginAsync(string email, string password)
        {
            var user = await UserManager
                .Users
                .FirstOrDefaultAsync(u => u.Email.Equals(email));

            if (user == null)
            {
                throw new LoginException(ErrorType.InvalidUsernameOrPassword.ToString());
            }

            var userHasValidPassword = await UserManager.CheckPasswordAsync(user, password);
            if (userHasValidPassword)
            {
                return await GenerateUserAuthenticationResult(user);
            }

            user.AccessFailedCount++;
            await UserManager.UpdateAsync(user);
            throw new LoginException(ErrorType.InvalidUsernameOrPassword.ToString());
        }

        public async Task<AuthenticationReadModel> RefreshUserTokenAsync(string userId, string refreshToken)
        {
            if (refreshToken == null)
            {
                throw new LoginException(ErrorType.TokenInvalid.ToString());
            }

            try
            {
                var user = await UserManager
                    .Users
                    .Include(p => p.RefreshTokens)
                    .FirstOrDefaultAsync(u => u.Id.Equals(userId)) ?? throw new NotFoundException("User Not Found");

                if (user.RefreshTokens == null || !user.RefreshTokens.Any(c => c.RefreshToken.Equals(refreshToken, StringComparison.InvariantCulture)))
                {
                    throw new LoginException(ErrorType.TokenInvalid.ToString());
                }

                return await GenerateUserAuthenticationResult(user);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "RefreshUserTokenAsync");
                throw;
            }
        }

        #endregion

        #region Private methods

        private async Task<AuthenticationReadModel> GenerateUserAuthenticationResult(UserEntity userEntity)
        {
            return await TokenService.GenerateUserTokensAsync(userEntity);
        }

        #endregion
    }
}
