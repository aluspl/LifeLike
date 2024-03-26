using System.Security.Claims;
using LifeLike.Services.Commons.Interfaces.Identity;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;

namespace LifeLike.Area.Client;

public class AuthorizationController : Controller
{
    private readonly IIdentityService _identityService;

    public AuthorizationController(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    [HttpPost("~/connect/token"), IgnoreAntiforgeryToken, Produces("application/json")]
    public async Task<IActionResult> Exchange()
    {
        var request = HttpContext.GetOpenIddictServerRequest();
        if (request.IsPasswordGrantType())
        {
            var identity = await _identityService.LoginAsync(request.Username, request.Password, request.GetScopes());
            
            // Returning a SignInResult will ask OpenIddict to issue the appropriate access/identity tokens.
            return SignIn(new ClaimsPrincipal(identity), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        if (request.IsRefreshTokenGrantType())
        {
            // Retrieve the claims principal stored in the refresh token.
            var result = await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

            var identity = await _identityService.RefreshUserTokenAsync(result.Principal);
            return SignIn(new ClaimsPrincipal(identity), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        throw new NotImplementedException("The specified grant type is not implemented.");
    }
}