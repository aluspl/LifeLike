#region Usings

using System.Security.Claims;
using System.Threading.Tasks;
using LifeLike.Database.Data.Entities.User;
using LifeLike.Services.Commons.Models.Identity;

#endregion

namespace LifeLike.Services.Commons.Interfaces.Identity
{
    public interface ITokenService
    {
        Task<AuthenticationReadModel> GenerateUserTokensAsync(UserEntity userEntity);

        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}
