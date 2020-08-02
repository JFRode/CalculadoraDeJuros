using CalculadoraDeJuros.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CalculadoraDeJuros.API.Controllers
{
    [Route("[controller]")]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly IShowMeTheCodeService _showMeTheCodeService;

        public ShowMeTheCodeController(IShowMeTheCodeService showMeTheCodeService) =>
            _showMeTheCodeService = showMeTheCodeService;

        /// <summary>
        /// Retorna links dos repositórios do projeto.
        /// </summary>
        /// <param name="cancellationToken"></param>
        [HttpGet]
        public async Task<string> GetAsync(CancellationToken cancellationToken) =>
            await _showMeTheCodeService.GetHyperlinks(cancellationToken);
    }
}