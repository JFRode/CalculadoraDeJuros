using CalculadoraDeJuros.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CalculadoraDeJuros.API.Controllers
{
    [Route("[controller]")]
    public class CalculadoraDeJurosController : ControllerBase
    {
        private readonly ICalculadoraDeJurosService _calculadoraDeJurosService;

        public CalculadoraDeJurosController(ICalculadoraDeJurosService calculadoraDeJurosService) =>
            _calculadoraDeJurosService = calculadoraDeJurosService;

        /// <summary>
        /// Calcula juros através do valor e tempo.
        /// </summary>
        /// <param name="valorInicial"></param>
        /// <param name="tempo"></param>
        /// <param name="cancellationToken"></param>
        [HttpGet("{valorInicial}&{tempo}")]
        public async Task<IActionResult> GetAsync(decimal valorInicial, int tempo, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _calculadoraDeJurosService.Calcular(valorInicial, tempo, cancellationToken);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.StackTrace);
            }
        }
    }
}