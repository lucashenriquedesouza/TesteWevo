using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Globalization;
using TesteWevo.Application.Application.Services;
using TesteWevo.Application.Domain.Contracts.Repositories;
using TesteWevo.Application.Domain.Contracts.Services;
using TesteWevo.Application.Infra.Repositories;

namespace TesteWevo.Application.Application.Configurations
{
    public static class ExtensionsConfigurations
    {

        public readonly static string ApiDescription = "Teste Wevo";
        public readonly static string ApiVersion = "V1";

        public static IServiceCollection ConfigureLanguage(this IServiceCollection services)
        {

            var cultureInfo = new CultureInfo("pt-BR");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            return services;

        }

        public static IServiceCollection ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services
                .AddTransient(x => configuration)
                //Service
                .AddTransient<IPersonService, PersonService>()
                //Repository
                .AddTransient<IPersonRepository, PersonRepository>();

            return services;

        }

        public static IServiceCollection ConfigureLogger(this IServiceCollection services)
        {

            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Debug()
                                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                                .MinimumLevel.Override("System", LogEventLevel.Error)
                                .Enrich.FromLogContext()
                                .Enrich.WithEnvironmentUserName()
                                .Enrich.WithMachineName()
                                .Enrich.WithProcessId()
                                .Enrich.WithProcessName()
                                .Enrich.WithThreadId()
                                .Enrich.WithThreadName()
                                .WriteTo.Console()
                                .WriteTo.File(@"Logs/log.txt")
                                .WriteTo.ApplicationInsights(TelemetryConfiguration.Active, TelemetryConverter.Traces)
                                .CreateLogger();

            return services;

        }

        public static IServiceCollection ConfigurarSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(swagger =>
            {

                swagger.SwaggerDoc(ApiVersion, new OpenApiInfo
                {
                    Version = ApiVersion,
                    Title = $"{ApiDescription} {ApiVersion}",
                    Description = ApiDescription,
                    Contact = new OpenApiContact
                    {
                        Name = "Teste Wevo"
                    }
                });

            });

            return services;
        }

        public static IApplicationBuilder UtilizarConfiguracaoSwagger(this IApplicationBuilder app)
        {

            app.UseSwagger(c =>
            {
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{ApiVersion}/swagger.json", $"{ApiDescription} API {ApiVersion}");
            });

            return app;

        }

    }
}
