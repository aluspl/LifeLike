#region Usings

using LifeLike.Common.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace LifeLike.Common.Api.Attributes
{
    public class ReturnEmptyAttribute : ProducesResponseTypeAttribute
    {
        public ReturnEmptyAttribute(int statusCode = StatusCodes.Status200OK)
            : base(typeof(EmptyEnvelope), statusCode)
        {
        }
    }
}
