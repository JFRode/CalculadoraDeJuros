using CalculadoraDeJuros.Application.Interfaces.Services;
using System.Threading;
using System.Threading.Tasks;

namespace CalculadoraDeJuros.Application.Services
{
    public class ShowMeTheCodeService : IShowMeTheCodeService
    {
        private const string LinkParaRepositorioDaApiTaxas = "https://github.com/JFRode/Taxas";
        private const string LinkParaRepositorioDaApiCalculadora = "https://github.com/JFRode/CalculadoraDeJuros";
        private const string LinkParaRepositorioSdk = "https://github.com/JFRode/SDK";

        public async Task<string> GetHyperlinks(CancellationToken cancellationToken) =>
            await Task.Run(() => MontarStringComHyperlinks(), cancellationToken);

        private string MontarStringComHyperlinks() =>
            $"API Taxas: {LinkParaRepositorioDaApiTaxas}\n" +
            $"API CalculadoraDeJuros: {LinkParaRepositorioDaApiCalculadora}\n" +
            $"SDK: {LinkParaRepositorioSdk}";
    }
}