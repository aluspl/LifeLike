#region Usings

using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using LifeLike.Common.Api.Models;
using LifeLike.Common.Exceptions;
using LifeLike.Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

#endregion

namespace LifeLike.Common.Api.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        #region Private Members

        private readonly RequestDelegate Next;
        private readonly IOptions<MvcNewtonsoftJsonOptions> JsonOptions;
        private readonly ILogger<ExceptionHandlingMiddleware> Logger;

        #endregion

        #region Constructor(s)

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            IOptions<MvcNewtonsoftJsonOptions> jsonOptions,
            ILoggerFactory loggerFactory)
        {
            Next = next ?? throw new ArgumentNullException(nameof(next));
            JsonOptions = jsonOptions ?? throw new ArgumentNullException(nameof(jsonOptions));
            Logger = loggerFactory?.CreateLogger<ExceptionHandlingMiddleware>() ?? throw new ArgumentNullException(nameof(loggerFactory));
        }

        #endregion

        #region Invoke

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (Exception exception)
            {
                context.Response.Clear();

                var envelope = new EmptyEnvelope();

                switch (exception)
                {
                    case NotFoundException noe:
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        envelope.Errors.Add(new Error("404", noe.Message));
                        Logger.LogError($"Exception: {noe.Message}");
                        break;
                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        envelope.Errors.Add(new Error("500", exception.Message));
                        Logger.LogWarning($"Exception: {exception.Message}");
                        break;
                }

                context.Response.ContentType = MediaTypeNames.Application.Json;
                var json = JsonConvert.SerializeObject(envelope, JsonOptions.Value.SerializerSettings);

                await context.Response.WriteAsync(json);
            }
        }

        #endregion
    }
}
