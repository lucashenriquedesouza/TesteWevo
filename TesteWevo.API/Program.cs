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

                Log.Information($"Início - Execução API.");

                host.Run();

            }
            catch (Exception ex)
            {

                Log.Fatal(ex, $"Erro - Execução API.");

            }
            finally
            {

                Log.Information($"Fim - Execução API.");
                Log.CloseAndFlush();

            }

        }

    }

}
