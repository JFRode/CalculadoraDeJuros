using System.Threading.Tasks;
using Xunit;

namespace CalculadoraDeJuros.DomainTest
{
    public class CalculadoraDeJurosTest
    {
        private readonly Domain.CalculadoraDeJuros.CalculadoraDeJuros _calculadoraDeJuros;

        public CalculadoraDeJurosTest() =>
            _calculadoraDeJuros = new Domain.CalculadoraDeJuros.CalculadoraDeJuros();

        [Fact]
        public async Task CalculadoraDeJuros_Calcula_ResultadoAcertivo()
        {
            var resultado = await Task.Run(() => _calculadoraDeJuros.Calcular(100, 5, 0.01M));
            Assert.Equal(105.1M, resultado);
        }
    }
}