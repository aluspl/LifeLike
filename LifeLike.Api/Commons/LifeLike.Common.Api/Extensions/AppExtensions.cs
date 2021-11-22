#region Usings

using LifeLike.Common.Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

#endregion

namespace LifeLike.Common.Api.Extensions
{
    public static class AppExtensions
    {
        #region Swagger

        public static IApplicationBuilder SetupSwaggerAndHealth(this IApplicationBuilder app, bool enable = false)
        {
            if (enable)
            {
                app.UseSwagger();

                app.UseSwaggerUI(options => { options.SwaggerEndpoint($"/swagger/swagger.json", $"LifeLike API"); });
            }

            app.UseHealthChecks("/healthcheck");

            return app;
        }

        #endregion

        #region ApiSetting

        public static IApplicationBuilder SetupApi(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            // return OK 200 for Azure AlwaysOn
            app.MapWhen(ctx => ctx.Request.Path.Value == "/", a => a.Run(async (context) =>
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("OK");
            }));

            return app;
        }

        #endregion

        #region Middlewares

        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            return app;
        }

        #endregion
    }
}
