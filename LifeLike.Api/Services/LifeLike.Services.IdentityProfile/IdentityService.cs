#region Usings

using System.Collections.Immutable;
using System.Security.Claims;
using LifeLike.Common.Exceptions;
using LifeLike.Database.Data.Entities.User;
using LifeLike.Services.Commons.Interfaces.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using static OpenIddict.Abstractions.OpenIddictConstants;

#endregion

namespace Lifelike.Services.IdentityService;

public class IdentityService : IIdentityService
{
    #region Private Members

    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;
    private readonly ILogger<IdentityService> _logger;

    #endregion

    public IdentityService(
        UserManager<UserEntity> userManagerProvider,
        ILogger<IdentityService> loggerProvider, 
        SignInManager<UserEntity> signInManager)
    {
        _logger = loggerProvider;
        _signInManager = signInManager;
        _userManager = userManagerProvider;
    }

    #region Traditional Login

    public async Task<ClaimsIdentity> LoginAsync(string email, string password, ImmutableArray<string> scopes)
    {
        var user = await _userManager.FindByNameAsync(email);
        if (user == null)
        {
            throw new LoginException("The username/password couple is invalid.");
        }

        // Validate the username/password parameters and ensure the account is not locked out.
        var result = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure: true);
        if (!result.Succeeded)
        {
            throw new LoginException("The username/password couple is invalid.");
        }

        // Create the claims-based identity that will be used by OpenIddict to generate tokens.
        var identity = new ClaimsIdentity(
            authenticationType: TokenValidationParameters.DefaultAuthenticationType,
            nameType: OpenIddictConstants.Claims.Name,
            roleType: OpenIddictConstants.Claims.Role);

        // Add the claims that will be persisted in the tokens.
        identity.SetClaim(OpenIddictConstants.Claims.Subject, await _userManager.GetUserIdAsync(user))
            .SetClaim(OpenIddictConstants.Claims.Email, await _userManager.GetEmailAsync(user))
            .SetClaim(OpenIddictConstants.Claims.Name, await _userManager.GetUserNameAsync(user))
            .SetClaims(OpenIddictConstants.Claims.Role,
                (await _userManager.GetRolesAsync(user)).ToImmutableArray());

        // Note: in this sample, the granted scopes match the requested scope
        // but you may want to allow the user to uncheck specific scopes.
        // For that, simply restrict the list of scopes before calling SetScopes.
        identity.SetScopes(scopes);
        identity.SetDestinations(GetDestinations);
        return identity;
    }

    public async Task<ClaimsIdentity> RefreshUserTokenAsync(ClaimsPrincipal principal)
    {
        // Retrieve the user profile corresponding to the refresh token.
        var user = await _userManager.FindByIdAsync(principal.GetClaim(Claims.Subject));
        if (user == null)
        {
            throw new LoginException("The refresh token is no longer valid.");
        }

        // Ensure the user is still allowed to sign in.
        if (!await _signInManager.CanSignInAsync(user))
        {
            throw new LoginException("The user is no longer allowed to sign in.");
        }

        var identity = new ClaimsIdentity(principal.Claims,
            authenticationType: TokenValidationParameters.DefaultAuthenticationType,
            nameType: Claims.Name,
            roleType: Claims.Role);

        // Override the user claims present in the principal in case they changed since the refresh token was issued.
        identity.SetClaim(Claims.Subject, await _userManager.GetUserIdAsync(user))
            .SetClaim(Claims.Email, await _userManager.GetEmailAsync(user))
            .SetClaim(Claims.Name, await _userManager.GetUserNameAsync(user))
            .SetClaims(Claims.Role, (await _userManager.GetRolesAsync(user)).ToImmutableArray());

        identity.SetDestinations(GetDestinations);
        return identity;
    }

    private static IEnumerable<string> GetDestinations(Claim claim)
    {
        // Note: by default, claims are NOT automatically included in the access and identity tokens.
        // To allow OpenIddict to serialize them, you must attach them a destination, that specifies
        // whether they should be included in access tokens, in identity tokens or in both.

        switch (claim.Type)
        {
            case Claims.Name:
                yield return Destinations.AccessToken;

                if (claim.Subject.HasScope(Permissions.Scopes.Profile))
                    yield return Destinations.IdentityToken;

                yield break;

            case Claims.Email:
                yield return Destinations.AccessToken;

                if (claim.Subject.HasScope(Permissions.Scopes.Email))
                    yield return Destinations.IdentityToken;

                yield break;

            case Claims.Role:
                yield return Destinations.AccessToken;

                if (claim.Subject.HasScope(Permissions.Scopes.Roles))
                    yield return Destinations.IdentityToken;

                yield break;

            // Never include the security stamp in the access and identity tokens, as it's a secret value.
            case "AspNet.Identity.SecurityStamp": yield break;

            default:
                yield return Destinations.AccessToken;
                yield break;
        }
    }

    #endregion
}