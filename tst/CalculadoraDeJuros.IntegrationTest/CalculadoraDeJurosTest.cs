using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CalculadoraDeJuros.IntegrationTest
{
    public class CalculadoraDeJurosTest
    {
        private readonly TestContext _testContext;

        public CalculadoraDeJurosTest() =>
            _testContext = new TestContext();

        [Fact]
        public async Task CalculadoraDeJurosGetRetornaNotFound()
        {
            var response = await _testContext.Client.GetAsync("/calculaJuros/");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task CalculadoraDeJurosGetRetornaValorCalculado()
        {
            var response = await _testContext.Client.GetAsync("/calculaJuros/100&5");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            responseContent.Should().Be("105.10");
        }
    }
}