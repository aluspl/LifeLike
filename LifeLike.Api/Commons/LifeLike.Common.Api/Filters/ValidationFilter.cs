#region Usings

using LifeLike.Common.Api.Models;
using LifeLike.Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

#endregion

namespace LifeLike.Common.Api.Filters
{
    public class ValidationFilter : IActionFilter
    {
        #region OnActionExecuting

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            var envelope = new EmptyEnvelope();

            foreach (var invalidProperty in context.ModelState)
            {
                foreach (var error in invalidProperty.Value.Errors)
                {
                    var propertyError = new Error(invalidProperty.Key, error.ErrorMessage, true);

                    envelope.Errors.Add(propertyError);
                }
            }

            context.Result = new BadRequestObjectResult(envelope);
        }

        #endregion

        #region OnActionExecuted

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            var envelope = new EmptyEnvelope();

            foreach (var invalidProperty in context.ModelState)
            {
                foreach (var error in invalidProperty.Value.Errors)
                {
                    var propertyError = new Error(invalidProperty.Key, error.ErrorMessage, true);

                    envelope.Errors.Add(propertyError);
                }
            }

            context.Result = new BadRequestObjectResult(envelope);
        }

        #endregion
    }
}