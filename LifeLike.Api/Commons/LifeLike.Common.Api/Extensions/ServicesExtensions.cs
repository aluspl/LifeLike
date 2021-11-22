#region Usings

using System.Collections.Generic;
using System.Diagnostics;
using LifeLike.Common.Api.Swagger;
using LifeLike.Common.Config;
using LifeLike.Common.Helpers;
using LifeLike.Database.Data.Entities.User;
using LifeLike.Database.Data.Stores;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

#endregion

namespace LifeLike.Common.Api.Extensions
{
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

            services.AddSwaggerGenNewtonsoftSupport();

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
            services
                .AddIdentity<UserEntity, RoleEntity>(options =>
                {
                    options.SignIn.RequireConfirmedEmail = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 4;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredUniqueChars = 0;
                })
                .AddRoleStore<PlatformUserRoleStore>()
                .AddUserStore<PlatformUserStore>()
                .AddDefaultTokenProviders();

            services
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = TokenValidation.GetTokenValidation(jwtOptions);
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
            });
            Debug.WriteLine("Using SQL");
            return services;
        }

        #endregion
    }
}
