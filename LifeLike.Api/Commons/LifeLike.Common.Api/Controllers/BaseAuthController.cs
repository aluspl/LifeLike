#region Usings

using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Const;
using LifeLike.Common.Exceptions;
using Microsoft.AspNetCore.Http;

#endregion

namespace LifeLike.Common.Api.Controllers;

/// <summary>
/// This controller is protected by "Bearer" attribute so you don't have to add this attribute to your controllers.
/// </summary>
[ReturnEmpty(StatusCodes.Status401Unauthorized)]
[ReturnEmpty(StatusCodes.Status403Forbidden)]
[Bearer]
public class BaseAuthController : BaseController
{
    #region Protected Properties

    protected string XToken => GetToken();

    protected string XUserId => GetUserId();

    #endregion

    #region Private Methods

    private string GetUserId()
    {
        if (!User.Claims.Any(c => c.Type.Equals(JwtClaims.Id)))
        {
            throw new NotFoundException("UserId Not Found");
        }

        var userId = User.Claims.FirstOrDefault(c => c.Type.Equals(JwtClaims.Id)).Value;
        return userId;
    }

    private string GetToken()
    {
        var token = Request.Headers["Authorization"].ToString();
        if (string.IsNullOrEmpty(token))
        {
            throw new NotFoundException("Token not found");
        }

        return token.Replace("Bearer ", string.Empty);
    }

    #endregion
}