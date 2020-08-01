using SDK.Dtos;
using System.Threading.Tasks;

namespace CalculadoraDeJuros.Application.Interfaces.Clients
{
    public interface ITaxasClient
    {
        Task<TaxaDeJurosDto> GetTaxaDeJuros();

        Task<string> GetAuthenticationToken();

        Task<string> RefreshAuthenticationToken();
    }
}