using System;
using LifeLike.Models;
using LifeLike.Repositories;
using LifeLIke.Repositories;
using LifeLIke.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LifeLIke
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<PortalContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
               //         options.UseSqlite(Configuration.GetConnectionString("ConnectionName"))
            );
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IRssReaderService, RssReaderService>();

            services.AddScoped<IEventLogRepository, EventLogsRepository>();
            services.AddScoped<ILinkRepository, LinkRepository>();
            services.AddScoped<IConfigRepository, ConfigRepository>();
            services.AddScoped<IGalleryRepository, GalleryRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<PortalContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Cookie settings
                options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(150);
                options.Cookies.ApplicationCookie.LoginPath = "/Account/L";
                options.Cookies.ApplicationCookie.LogoutPath = "/Account/LogOut";
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            PortalContext context)
        {
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
            
            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "pages",
                    template: "Page/{*id}",
                    defaults: new {controller = "Page", action = "Detail"});
                routes.MapRoute(
                    name: "photos",
                    template: "Photos/{*id}",
                    defaults: new {controller = "Photos", action = "Detail"});
            });
            DbInitializer.Initialize(context);
        }
    }
}