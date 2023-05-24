using MinhaMega.Models;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace MinhaMega.Api
{
    public class LoteriaApi : ILoteriaApi
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoteriaApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private HttpClient httpClient => _httpClientFactory.CreateClient();
        public async Task<string> Concurso(int? numeroConcurso)
         {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("");
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsStringAsync().Result;
                return string.Empty;
            }catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
        }
    }
}
