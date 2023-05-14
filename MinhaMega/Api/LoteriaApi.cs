using System.Net;
using System.Text.Json.Nodes;

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
#if DEBUG
                var mega = new MockJSon().MegaSenaString();
                return mega;
#endif

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
