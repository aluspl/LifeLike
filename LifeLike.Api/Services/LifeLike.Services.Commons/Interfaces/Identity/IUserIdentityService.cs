#region Usings

using System.Threading.Tasks;
using LifeLike.Services.Commons.Models.Identity;

#endregion

namespace LifeLike.Services.Commons.Interfaces.Identity
{
    public interface IUserIdentityService
    {
        #region User

        Task<AuthenticationReadModel> LoginAsync(string email, string password);

        Task<AuthenticationReadModel> RefreshUserTokenAsync(string refreshToken, string token);

        #endregion
    }
}
