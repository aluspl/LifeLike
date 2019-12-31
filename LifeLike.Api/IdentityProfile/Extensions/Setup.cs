using Microsoft.Extensions.DependencyInjection;

namespace LifeLike.IdentityProfile.Extensions
{
    public static class Setup
    {
        public static IServiceCollection SetupIdentity(this IServiceCollection services)
        {
            //services.AddIdentity<User, IdentityRole>()
            //    .AddEntityFrameworkStores<PortalContext>()
            //    .AddDefaultTokenProviders();
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = "/Account/Login";
            //    options.LogoutPath = "/Account/Logout";

            //    options.ExpireTimeSpan = TimeSpan.FromDays(50);
            //});
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            //services
            //    .AddAuthentication(options =>
            //    {
            //        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            //    })
            //    .AddJwtBearer(cfg =>
            //    {
            //        cfg.RequireHttpsMetadata = false;
            //        cfg.SaveToken = true;
            //        cfg.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidIssuer = Configuration["JwtIssuer"],
            //            ValidAudience = Configuration["JwtIssuer"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
            //            ClockSkew = TimeSpan.Zero // remove delay of token when expire
            //        };
            //    });
            return services;
        }
    }
}
