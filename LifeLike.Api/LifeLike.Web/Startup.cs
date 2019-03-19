using AutoMapper;
using LifeLike.CloudService.BlobStorage;
using LifeLike.CloudService.CosmosDB;
using LifeLike.CloudService.TableStorage;
using LifeLike.Data;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using LifeLike.Services;
using LifeLike.Services.Profiles;
using LifeLike.Services.Services;
using LifeLike.Services.Structures;
using LifeLike.Shared;
using LifeLike.Shared.Services;
using LifeLike.Web.Services.Logs;
using LifeLike.Web.Services.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Serilog;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LifeLike.Web
{
    public class Startup
    {
        public readonly IConfiguration Configuration;

        public Startup(IHostingEnvironment env, IConfiguration config)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("log.txt",
                    rollingInterval: RollingInterval.Month,
                    rollOnFileSizeLimit: true)
                .CreateLogger();
            Configuration = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog(dispose: true);
                loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });

            var connection = Configuration["DB"];
            if (connection == null)
            {
                services.AddDbContext<PortalContext>(options =>
                    options.UseSqlite("Data Source=lifelike.db"));
            }
            else
            {
                services.AddDbContext<PortalContext>(options =>
                       options.UseSqlServer(connection,
                       b => b.MigrationsAssembly("LifeLike.Web")));
            }

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            if (Configuration["CosmosDBEndpoint"] != null)
                services.AddScoped<IUnitOfWork, CosmosUnitOfWork>();
            else
                services.AddScoped<IUnitOfWork, UnitOfWork>();
            if (Configuration["BlobStorage"] != null)
            {
                services.AddScoped<IBlobStorage, BlobStorage>();
                services.AddScoped<IQueueService, CloudService.Queue.QueueService>();
            }
            else
            {
                services.AddScoped<IBlobStorage, LocalBlobStorage>();
                services.AddScoped<IQueueService, LifeLike.Services.CloudServices.QueueService>();
            }
            services.AddScoped<IStatisticService, StatisticService>();
            services.AddScoped<ITableStorage, TableStorage>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ILinkService, LinkRepository>();
            services.AddScoped<IConfigService, ConfigService>();
            services.AddScoped<IPageService, PageService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IVideoService, VideoService>();

            SetupIdentity(services);
            services.AddSwaggerSetting();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            SetupCORS(services);
            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            PortalContext context)
        {
            // GenerateDB(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseExceptionMiddleware();
            app.UseSwaggerSetting();

            var option = new RewriteOptions().AddRedirect("^$", "swagger");
            app.UseRewriter(option);
            // app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            DbInitializer.Initialize(context);
        }


        private void SetupCORS(IServiceCollection services)
        {
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                     .WithOrigins(Configuration["Frontend"])
                    .AllowAnyMethod()
                    //.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    );
            });
        }

        private void SetupIdentity(IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<PortalContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";

                options.ExpireTimeSpan = TimeSpan.FromDays(50);
            });
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });
        }

    }
}