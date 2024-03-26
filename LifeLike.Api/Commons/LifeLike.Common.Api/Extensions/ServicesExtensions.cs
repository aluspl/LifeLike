#region Usings

using System.Diagnostics;
using LifeLike.Common.Api.Swagger;
using LifeLike.Common.Config;
using LifeLike.Database.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

#endregion

namespace LifeLike.Common.Api.Extensions;

public static class ServicesExtensions
{
    #region Swagger

    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("LifeLike API", new OpenApiInfo() { Title = $"LifeLike", Version = "2137" });


            options.DocumentFilter<DateTimeDocumentFilter>();
            options.DocumentFilter<LowercaseDocumentFilter>();
            options.DescribeAllParametersInCamelCase();

            options.MapType<FileContentResult>(() => new OpenApiSchema
            {
                Type = "file",
            });

            options.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme,
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                },
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

    #region Auth

    public static IServiceCollection AddAuthentication(this IServiceCollection services, JWTConfig jwtOptions)
    {
        services.AddOpenIddict()
            // Register the OpenIddict core components.
            .AddCore(options =>
            {
                // Configure OpenIddict to use the Entity Framework Core stores and models.
                // Note: call ReplaceDefaultEntities() to replace the default OpenIddict entities.
                options.UseEntityFrameworkCore()
                       .UseDbContext<EfContext>();

                // Enable Quartz.NET integration.
                options.UseQuartz();
            })

            // Register the OpenIddict server components.
            .AddServer(options =>
            {
                // Enable the token endpoint.
                options.SetTokenEndpointUris("connect/token");

                // Enable the password and the refresh token flows.
                options.AllowPasswordFlow()
                       .AllowRefreshTokenFlow();

                // Accept anonymous clients (i.e clients that don't send a client_id).
                options.AcceptAnonymousClients();

                // Register the signing and encryption credentials.
                options.AddDevelopmentEncryptionCertificate()
                       .AddDevelopmentSigningCertificate();

                // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
                options.UseAspNetCore()
                       .EnableTokenEndpointPassthrough();
            })

            // Register the OpenIddict validation components.
            .AddValidation(options =>
            {
                // Import the configuration from the local OpenIddict server instance.
                options.UseLocalServer();

                // Register the ASP.NET Core host.
                options.UseAspNetCore();
            });

        return services;
    }

    #endregion

    #region Database

    public static IServiceCollection UseSql<T>(this IServiceCollection services, string connection, string migrationAssemblyName)
        where T : DbContext
    {
        services.AddDbContext<T>(options =>
        {
            options.UseSqlServer(connection, option =>
            {
                option.MigrationsAssembly(migrationAssemblyName);
            });
            
            options.UseOpenIddict();
        });
        Debug.WriteLine("Using SQL");
        return services;
    }

    #endregion
}