using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LifeLike.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        private static IWebHost BuildWebHost(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables()
                .AddJsonFile("app.settings.json")
                .Build();

            return WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:80")
                .UseKestrel()
                .UseApplicationInsights()
                .UseIISIntegration()
                .UseConfiguration(builder)
                .UseApplicationInsights()
                .ConfigureAppConfiguration((context, config) =>
                 {
                     var builtConfig = config.Build();

                     config.AddAzureKeyVault(
                         $"https://{builtConfig["KeyVaultName"]}.vault.azure.net/",
                         builtConfig["AzureADApplicationId"],
                         builtConfig["AzureADPassword"]);
                 }
                )
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
        }
    }
}