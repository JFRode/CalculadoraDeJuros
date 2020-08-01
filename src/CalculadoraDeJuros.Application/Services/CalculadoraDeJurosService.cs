using CalculadoraDeJuros.Application.Interfaces.Clients;
using CalculadoraDeJuros.Application.Interfaces.Services;
using System.Threading;
using System.Threading.Tasks;

namespace CalculadoraDeJuros.Application.Services
{
    public class CalculadoraDeJurosService : ICalculadoraDeJurosService
    {
        private readonly ITaxasClient _taxasClient;

        public CalculadoraDeJurosService(ITaxasClient taxasClient)
        {
            _taxasClient = taxasClient;
        }

        public async Task<decimal> Calcular(decimal valorInicial, int tempo, CancellationToken cancellationToken)
        {
            var calculadora = new Domain.CalculadoraDeJuros.CalculadoraDeJuros();
            var taxaDeJurosDto = await _taxasClient.GetTaxaDeJuros();

            return await Task.Run(() => calculadora.Calcular(valorInicial, tempo, taxaDeJurosDto.Percentual), cancellationToken);
        }
    }
}