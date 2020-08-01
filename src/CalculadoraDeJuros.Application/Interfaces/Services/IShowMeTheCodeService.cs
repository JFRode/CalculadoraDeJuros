using System.Threading;
using System.Threading.Tasks;

namespace CalculadoraDeJuros.Application.Interfaces.Services
{
    public interface IShowMeTheCodeService
    {
        Task<string> GetHyperlinks(CancellationToken cancellationToken);
    }
}