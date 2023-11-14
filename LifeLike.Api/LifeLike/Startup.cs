using System.Reflection;
using LifeLike.Common.Api.Extensions;
using LifeLike.Common.Api.Filters;
using LifeLike.Common.Config;
using LifeLike.Common.Const;
using LifeLike.Database.Data;
using LifeLike.Database.Data.Interfaces;
using LifeLike.Database.Data.Repository;
using LifeLIke.Services.All;
using LifeLike.Services.Media.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Scrutor;

namespace LifeLike;

public class Startup
{
    private const string MigrationsAssemblySuffixName = "Database.Migrations";
    private const string ServicesAssemblySuffixName = "Services";
    private const string BlobStorage = "BlobStorage";

    public readonly IConfiguration Configuration;
    private string MigrationsAssemblyName => $"{typeof(Startup).Namespace.Split('.')[0]}.{MigrationsAssemblySuffixName}";

    private string ServicesAssemblyName => $"{typeof(Startup).Namespace.Split('.')[0]}.{ServicesAssemblySuffixName}";

    private Assembly[] ServiceAssemblies => typeof(ServicesAssembly)
        .Assembly
        .GetReferencedAssemblies()
        .Where(an => an.FullName.StartsWith(ServicesAssemblyName))
        .Select(a => Assembly.Load(a))
        .ToArray();

    public Startup(IConfiguration config)
    {
        Configuration = config;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddControllers(opt => opt.Filters.Add(typeof(ValidationFilter)))
            .AddNewtonsoftJson(options => options.SerializerSettings.SetupJsonSettings())
            .ConfigureApiBehaviorOptions(opt => { opt.SuppressModelStateInvalidFilter = true; });

        var connectionString = Configuration.GetConnectionString(Config.ConnectionString);
        services.UseSql<EfContext>(connectionString, MigrationsAssemblyName);

        var jwtOptions = services.BindConfigurationWithValidation<JWTConfig>(Configuration, "Jwt");

        services.AddAuthentication(jwtOptions);
        services.AddSwaggerConfiguration();
        services.AddHealthStatus();
        services.AddMemoryCache();
        services.AddCors(opt => opt.AddPolicy(
            "AllowAll",
            builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));

        var connection = Configuration.GetConnectionString("defaultConnection");
        services.UseSql<EfContext>(connection, MigrationsAssemblyName);

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

        services.Scan(scan =>
            scan.FromAssemblies(ServiceAssemblies)
                .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<DatabaseInitializer>();

        if (Configuration[BlobStorage] != null)
        {
            services.UseCloudServices();
        }

        // Automapper

        services.BindConfigurationWithValidation<SeedConfigs>(Configuration, "Seed");
        services.BindConfigurationWithValidation<AzureStorageConfig>(Configuration, "AzureStorage");

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        app.UseStaticFiles();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseExceptionMiddleware();
        app.UseCors("AllowSelected");
        app.SetupSwaggerAndHealth(Configuration.GetValue<bool>("EnableSwagger"));
        app.SetupApi();
    }
}