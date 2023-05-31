using System.Text.Json;

namespace MinhaMega.Api
{
    public class LoteriaApi<T> : ILoteriaApi<T> where T : class
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string _baseAddress = "https://servicebus2.caixa.gov.br/portaldeloterias/api";

        public LoteriaApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private HttpClient _httpClient => _httpClientFactory.CreateClient();
        public async Task<T> Concurso(string jogo,string numeroConcurso)
         {
            try
             {
                var response = await _httpClient.GetAsync($"{_baseAddress}/{jogo.ToLower()}/{numeroConcurso}");

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    if (result.Length == 0)
                        throw new IndexOutOfRangeException(result);
                    return JsonSerializer.Deserialize<T>(result);
                }else
                throw new Exception($"status code:{response.StatusCode}, {response.Content}");
            }
            finally
            {
                _httpClient.Dispose();
            }
        }
    }
}
