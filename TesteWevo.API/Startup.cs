using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using TesteWevo.Application.Application.Configurations;
using TesteWevo.Application.Domain.DTOs;

namespace TesteWevo.API
{

    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;

        }

        public void ConfigureServices(IServiceCollection services)
        {

            services
                .AddHttpContextAccessor()
                .Configure<Configurations>(Configuration)
                .AddOptions()
                .ConfigureLanguage()
                .ConfigureDependencies(Configuration)
                .ConfigureLogger()
                .ConfigurarSwagger()
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services
                .AddControllers()
                .AddNewtonsoftJson();

            services
                .AddMvc(opt =>
                {
                    opt.EnableEndpointRouting = false;
                })
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            try
            {

                app
                    .UtilizarConfiguracaoSwagger()
                    .UseMvcWithDefaultRoute();

            }
            catch (Exception ex)
            {

                Log.Error("Ocorreu um erro ao inicializar a aplicação. {Exception}:", ex.Message);

            }

        }

    }

}
