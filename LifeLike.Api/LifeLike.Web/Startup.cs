using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using LifeLike.Data.Models;
using LifeLike.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Serilog;
using Swashbuckle.AspNetCore.Swagger;
using LifeLike.Web.Services.Swagger;
using LifeLike.Services;
using LifeLike.Data;
using LifeLike.Services.Profiles;
using LifeLike.Web.Services.Logs;
using Microsoft.AspNetCore.Rewrite;
using System.Net;

namespace LifeLike.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {  
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("log.txt",
                    rollingInterval: RollingInterval.Month,
                    rollOnFileSizeLimit: true)
                .CreateLogger();
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)     
                .AddEnvironmentVariables()
                .AddJsonFile("app.settings.json");
            // if (env.IsDevelopment())
                // builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddLogging(loggingBuilder =>
                loggingBuilder.AddSerilog(dispose: true));
            var connection = Configuration.GetConnectionString("DB");
            if (connection == null)
            {
                services.AddDbContext<PortalContext>(options =>
                    options.UseSqlite("Data Source=lifelike.db"));
                Debug.WriteLine("Using SQLite");
            }
            else
            {
                services.AddDbContext<PortalContext>(options =>
                       options.UseSqlServer(connection,
                       b => b.MigrationsAssembly("LifeLike.Web")));
                Debug.WriteLine("Using SQL");
            }
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ILinkService, LinkRepository>();
            services.AddScoped<IConfigService, ConfigService>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IPageService, PageService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IVideoService, VideoService>();
            services.AddCors();
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
            // services.AddSpaStaticFiles(configuration =>
            // {
            //     configuration.RootPath = "ClientApp/dist";
            // });
            services.AddSwaggerSetting();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
                options.KnownProxies.Add(IPAddress.Parse("172.22.0.1"));
            });
            services.AddMvc();
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

        }

        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            PortalContext context)
        {
            GenerateDB(app);

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

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
            app.UseHttpsRedirection();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            // app.UseSpa(spa =>
            // {
            //     spa.Options.SourcePath = "ClientApp";

            //     if (env.IsDevelopment())
            //     {
            //         spa.UseAngularCliServer(npmScript: "start");
            //     }
            // });
            DbInitializer.Initialize(context);
        }

        private static void GenerateDB(IApplicationBuilder app)
        {
            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<PortalContext>().Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to migrate or seed database");
            }
        }

    }
}