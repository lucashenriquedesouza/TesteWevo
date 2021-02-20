using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace TesteWevo.API
{

    public class Program
    {

        protected Program()
        {

        }

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost
                .CreateDefaultBuilder(args)
                .UseSerilog(dispose: true)
                .UseStartup<Startup>()
                .UseConfiguration(Configuration);

        static void Main(string[] args)
        {

            try
            {

                var host = CreateWebHostBuilder(args).Build();

                Log.Information($"In�cio - Execu��o API.");

                host.Run();

            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"Erro - Execu��o API.");

            }
            finally
            {

                Log.Information($"Fim - Execu��o API.");
                Log.CloseAndFlush();

            }

        }

    }

}
