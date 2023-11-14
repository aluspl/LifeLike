#region Usings

using Microsoft.AspNetCore.Authorization;

#endregion

namespace LifeLike.Common.Api.Attributes;

public class BearerAttribute : AuthorizeAttribute
{
    #region Constructor(s)

    public BearerAttribute()
        : base()
    {
        AuthenticationSchemes = "Bearer";
    }

    public BearerAttribute(string role)
        : base()
    {
        AuthenticationSchemes = "Bearer";
    }

    #endregion
}