using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace Flash.Park
{
    public class Program
    {
        private static readonly string HostingEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        private static readonly string ProjectName = Assembly.GetEntryAssembly().GetName().Name;

        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddEnvironmentVariables()
           .Build();

        public static int Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();
            var logger = host.Services.GetService<ILogger<Program>>();
            try
            {
                logger.LogDebug($"ASPNETCORE_ENVIRONMENT : {HostingEnvironment}.");
                if (HostingEnvironment is null)
                {
                    logger.LogInformation("ASPNETCORE_ENVIRONMENT is null and appsettings.Development.json file was loaded.");
                }
                else
                {
                    logger.LogInformation($"appsettings.{HostingEnvironment}.json file was loaded.");
                }

                logger.LogInformation($"Getting the motors running for {ProjectName}...");
                host.Run();
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

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseConfiguration(Configuration)
                .UseSerilog();
    }
}
