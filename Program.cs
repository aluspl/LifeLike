using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace LifeLike
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();         
        }
        public static IWebHost BuildWebHost(string[] args)
        {
            var portNumber = args.Length == 0 ? "5000" : args[0];
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseIISIntegration()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
        }

    }
}