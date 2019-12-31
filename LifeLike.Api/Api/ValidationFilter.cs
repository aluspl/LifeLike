using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shared;

namespace LifeLike.Web
{
    internal class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            var envelope = new Envelope<EmptyData>(new EmptyData());

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

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.ModelState.IsValid)
            {
                return;
            }

            var envelope = new Envelope<EmptyData>(new EmptyData());

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
    }
}