using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CalculadoraDeJuros.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraDeJuros.API.Controllers
{
    [Route("[controller]")]
    public class ShowMeTheCodeController : Controller
    {
        private readonly IShowMeTheCodeService _showMeTheCodeService;

        public ShowMeTheCodeController(IShowMeTheCodeService showMeTheCodeService)
        {
            _showMeTheCodeService = showMeTheCodeService;
        }

        [HttpGet]
        public async Task<string> GetAsync(CancellationToken cancellationToken)
        {
            return await _showMeTheCodeService.GetHyperlinks(cancellationToken);
        }
    }
}