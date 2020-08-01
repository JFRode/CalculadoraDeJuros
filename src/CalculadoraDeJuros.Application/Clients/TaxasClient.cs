using CalculadoraDeJuros.Application.Interfaces.Clients;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polly;
using SDK.Dtos;
using SDK.KeyVault;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraDeJuros.Application.Clients
{
    public class TaxasClient : ITaxasClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private static string AuthenticationToken = "";

        public TaxasClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TaxaDeJurosDto> GetTaxaDeJuros()
        {
            var taxaDeJurosDto = new TaxaDeJurosDto();
            var policy = CreateTokenRefreshPolicy();

            var response = await policy.ExecuteAsync(context =>
            {
                var client = _httpClientFactory.CreateClient("TaxasAPI");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationToken);
                return client.GetAsync("taxaJuros");
            }, new Dictionary<string, object>
            {
                {"access_token", AuthenticationToken}
            });

            string apiResponse = await response.Content.ReadAsStringAsync();
            taxaDeJurosDto.Percentual = JsonConvert.DeserializeObject<decimal>(apiResponse);

            return taxaDeJurosDto;
        }

        public async Task<string> GetAuthenticationToken()
        {
            var client = _httpClientFactory.CreateClient("TaxasAPI");

            var content = new StringContent(JsonConvert.SerializeObject(AuthenticationKeys.TaxasApi), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("Token", content);

            string apiResponse = await response.Content.ReadAsStringAsync();

            var token = JObject.Parse(apiResponse)
                .GetValue("token")
                .ToString();

            return token;
        }

        public async Task<string> RefreshAuthenticationToken()
        {
            var token = await GetAuthenticationToken();
            AuthenticationToken = token;
            return token;
        }

        private IAsyncPolicy<HttpResponseMessage> CreateTokenRefreshPolicy()
        {
            var policy = Policy
                .HandleResult<HttpResponseMessage>(message => message.StatusCode == HttpStatusCode.Unauthorized)
                .RetryAsync(1, async (result, retryCount, context) =>
                {
                    if (context.ContainsKey("access_token"))
                    {
                        var newAccessToken = await RefreshAuthenticationToken();
                        if (newAccessToken != null)
                            context["access_token"] = newAccessToken;
                    }
                });

            return policy;
        }
    }
}