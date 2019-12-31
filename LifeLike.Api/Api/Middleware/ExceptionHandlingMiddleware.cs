using LifeLike.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Shared;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace LifeLike.Web.Services
{
    public class ExceptionHandlingMiddleware
    {
        #region private

        private readonly RequestDelegate Next;
        private readonly ILogger<ExceptionHandlingMiddleware> Logger;

        #endregion

        #region constructors

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILoggerFactory loggerFactory)
        {
            Next = next ?? throw new ArgumentNullException(nameof(next));
            Logger = loggerFactory?.CreateLogger<ExceptionHandlingMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        #endregion

        #region invoke

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (Exception exception)
            {
                context.Response.Clear();

                var envelope = new Envelope<EmptyData>(new EmptyData())
                {
                    Errors = new List<Error> { }
                };
                switch (exception)
                {
                    //case NotFoundException noe:
                    //    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    //    envelope.Errors.Add(new Error("404", noe.Message));
                    //    Logger.LogInformation($"Exception: {noe.Message}");
                    //    break;
                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        envelope.Errors.Add(new Error("500", exception.Message));
                        Logger.LogWarning($"Exception: {exception.Message}");
                        break;
                }

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(envelope));

                return;
            }
        }

        #endregion
    }
}
