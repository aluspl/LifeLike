using LifeLike.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Extensions
{
    public static class AppExtensions
    {
        #region Swagger
        public static IApplicationBuilder SetupSwaggerAndHealth(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsProduction())
            {
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api V1");                    
                });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });         

            return app;
        }

        public static IServiceCollection SetupCORS(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                     .WithOrigins(configuration["Frontend"])
                    .AllowAnyMethod()
                    //.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    );
            });
            return services;
        }
        #endregion

        #region Migrations
        public static IHost Migrate(this IHost host)
        {
            using (var scope = host.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                using (var context = scope.ServiceProvider.GetRequiredService<PortalContext>())
                {
                    context.Database.Migrate();
                    DbInitializer.Initialize(context);
                }
            }

            return host;
        }
        #endregion
        #region Configuration

        public static T BindConfigurationWithValidation<T>(this IServiceCollection services, IConfiguration configuration, string sectionName)
            where T : class, new()
        {
            var config = new T();
            configuration.GetSection(sectionName).Bind(config);

            var vc = new System.ComponentModel.DataAnnotations.ValidationContext(config);
            ICollection<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(config, vc, results, true);

            if (!isValid)
            {
                foreach (var error in results)
                {
                    throw new Exception(error.ToString());
                }
            }

            services.AddOptions<T>()
               .Bind(configuration.GetSection(sectionName));

            return config;
        }

        #endregion

        #region swagger
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AmRest API",
                    Description = "Web API written in .NET 3.1",
                });
               
            });

            return services;
        }

        #endregion

        #region HealthStatus
        public static IServiceCollection AddHealthStatus(this IServiceCollection services)
        {
            services.AddHealthChecks();
            return services;
        }
        #endregion

    }
}
