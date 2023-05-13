using System.Net;

namespace MinhaMega.Api
{
    public class LoteriaApi : ILoteriaApi
    {
        private readonly HttpClient httpClient = new();
        string urlBase = "https://servicebus2.caixa.gov.br/portaldeloterias/api/megasena";

        public async Task<string> Concurso(int? numeroConcurso)
        {
            httpClient.BaseAddress = new Uri(urlBase);
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("");
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsStringAsync().Result;
            }catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }
            
            return "Sem Resultado";
        }
    }
}
