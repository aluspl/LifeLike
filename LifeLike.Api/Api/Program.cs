using System;
using System.IO;
using Api.Extensions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace LifeLike.Web
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                                  .MinimumLevel.Debug()
                                  .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                                  .Enrich.FromLogContext()
                                  .WriteTo.Console(new RenderedCompactJsonFormatter())
                                  .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Migrate().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .UseSerilog()
                 .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}