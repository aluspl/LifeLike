#region Usings

using System;
using LifeLike.Common.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace LifeLike.Common.Api.Attributes
{
    public class ReturnAttribute : ProducesResponseTypeAttribute
    {
        #region Constructor(s)

        public ReturnAttribute(Type objType, int statusCode = StatusCodes.Status200OK)
            : base(statusCode)
        {
            Type = typeof(Envelope<>).MakeGenericType(objType);
        }

        #endregion
    }
}
