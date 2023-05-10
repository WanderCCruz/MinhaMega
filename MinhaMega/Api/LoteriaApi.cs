using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;

namespace MinhaMega.Api
{
    public class LoteriaApi : ILoteriaApi
    {
        private readonly HttpClient httpClient;
        string urlBase = "https://servicebus2.caixa.gov.br/portaldeloterias/api/megasena/";
        public LoteriaApi(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> Concurso(int numeroConcurso)
        {
            httpClient.BaseAddress = new Uri(urlBase+numeroConcurso.ToString());
            HttpResponseMessage response = await httpClient.GetAsync("");
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsStringAsync().Result;
            return null;
        }
    }
}
