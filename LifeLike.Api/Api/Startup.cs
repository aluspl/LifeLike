using Api.Extensions;
using AutoMapper;
using FluentValidation.AspNetCore;
using LifeLike.CloudService.CosmosDB;
using LifeLike.CloudService.Extensions;
using LifeLike.Data;
using LifeLike.Data.Extensions;
using LifeLike.IdentityProfile.Extensions;
using LifeLike.LocalServices;
using LifeLike.Repositories;
using LifeLike.Services;
using LifeLike.Shared;
using LifeLike.Shared.Structures;
using LifeLike.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LifeLike.Web
{
    public class Startup
    {
        private const string CosmosDB = "CosmosDBEndpoint";
        private const string BlobStorage = "BlobStorage";

        public readonly IConfiguration Configuration;

        public Startup(IWebHostEnvironment env, IConfiguration config)
        {
            Configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(opt => opt.Filters.Add(typeof(ValidationFilter)))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(typeof(Services.Domain).Assembly))
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                    options.JsonSerializerOptions.WriteIndented = true;
                });

            services.AddHealthStatus();
            services.AddSwaggerConfiguration();
            services.AddCors(opt => opt.AddPolicy("AllowAll",
               builder => builder
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()));

            var connection = Configuration["DB"];
            if (connection == null)
            {
                services.SetupSQLite(connection);             
            }
            else
            {
                services.SetupSQL(connection);               
            }

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<ILinkService, LinkService>();
            services.AddScoped<IConfigService, ConfigService>();
            services.AddScoped<IPageService, PageService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IVideoService, VideoService>();

            if (Configuration[CosmosDB] != null)
                services.AddScoped(typeof(IRepository<>), typeof(DocumentDBRepository<>));
            else
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            if (Configuration[BlobStorage] != null)
            {
                services.UseCloudServices();
            }
            else
            {
                services.UseLocalServices();
            }

            services.SetupIdentity();

            services.AddAutoMapper(
                typeof(Startup).Assembly,
                typeof(Services.Domain).Assembly,
                typeof(Data.Data).Assembly);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {         
            app.UseStaticFiles();
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.SetupSwaggerAndHealth(env);
            app.UseCors("AllowAll");
            app.UseSerilogRequestLogging();
            app.SetupApi();

        }
    }
}