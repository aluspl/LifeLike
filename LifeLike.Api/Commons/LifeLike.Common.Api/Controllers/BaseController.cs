#region Usings

using LifeLike.Common.Api.Attributes;
using LifeLike.Common.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace LifeLike.Common.Api.Controllers;

[ApiController]
[ReturnEmpty(StatusCodes.Status400BadRequest)]
public class BaseController : ControllerBase
{
    #region Constructor(s)

    #endregion

    #region Protected Methods

    protected IActionResult GetResult(int statusCode = StatusCodes.Status200OK)
    {
        return GetResult(new EmptyData(), statusCode);
    }

    protected IActionResult GetResult<T>(T data, int statusCode = StatusCodes.Status200OK)
    {
        var envelope = new Envelope<T>(data);
        return new ObjectResult(envelope)
        {
            StatusCode = statusCode
        };
    }

    #endregion
}