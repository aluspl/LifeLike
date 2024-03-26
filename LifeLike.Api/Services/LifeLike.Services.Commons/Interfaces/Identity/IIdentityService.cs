#region Usings

#endregion

using System.Collections.Immutable;
using System.Security.Claims;

namespace LifeLike.Services.Commons.Interfaces.Identity;

public interface IIdentityService
{
    #region User

    Task<ClaimsIdentity> LoginAsync(string email, string password, ImmutableArray<string> immutableArray);

    Task<ClaimsIdentity> RefreshUserTokenAsync(ClaimsPrincipal principal);

    #endregion
}