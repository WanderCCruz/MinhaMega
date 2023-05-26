﻿using MinhaMega.Models;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Nodes;

namespace MinhaMega.Api
{
    public class LoteriaApi : ILoteriaApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string baseAddress = "https://servicebus2.caixa.gov.br/portaldeloterias/api";

        public LoteriaApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private HttpClient _httpClient => _httpClientFactory.CreateClient();
        public async Task<string> Concurso(int? numeroConcurso)
         {
            try
            {
                var response = await _httpClient.GetAsync($"{baseAddress}/megasena/{numeroConcurso}");

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
