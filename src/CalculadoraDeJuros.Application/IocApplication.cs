using CalculadoraDeJuros.Application.Clients;
using CalculadoraDeJuros.Application.Interfaces.Clients;
using CalculadoraDeJuros.Application.Interfaces.Services;
using CalculadoraDeJuros.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraDeJuros.Application
{
    public static class IocApplication
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) =>
            services.AddScoped<ICalculadoraDeJurosService, CalculadoraDeJurosService>()
                    .AddScoped<ITaxasClient, TaxasClient>()
                    .AddScoped<IShowMeTheCodeService, ShowMeTheCodeService>();
    }
}