using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace LifeLike.Web.Controllers
{

    [ApiController]
    [ProducesResponseType(typeof(Envelope<EmptyData>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Envelope<EmptyData>), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Envelope<EmptyData>), StatusCodes.Status403Forbidden)]
    public class BaseController : ControllerBase
    {
    }
}