using System.Threading;
using System.Threading.Tasks;

namespace CalculadoraDeJuros.Application.Interfaces.Services
{
    public interface ICalculadoraDeJurosService
    {
        Task<decimal> Calcular(decimal valorInicial, int tempo, CancellationToken cancellationToken);
    }
}