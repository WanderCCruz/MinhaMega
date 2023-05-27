﻿using MinhaMega.Models;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

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
        public async Task<T> Concurso(string jogo,int? numeroConcurso)
         {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseAddress}/{jogo}/{numeroConcurso}");

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    if (result.Length == 0)
                        throw new IndexOutOfRangeException(result);
                    return JsonSerializer.Deserialize<T>(result);
                }else
                throw new Exception($"status code:{response.StatusCode}, {response.Content}");
            }
            catch (IndexOutOfRangeException)
            {
                await Shell.Current.DisplayAlert("Atenção", "Concurso não encontrado, tente outro numero", "OK");
                await Shell.Current.GoToAsync(nameof(MainPage));
            }
            catch(Exception e)
            {
                await Shell.Current.DisplayAlert("Atenção",e.InnerException.Message, "OK");
                await Shell.Current.GoToAsync(nameof(MainPage));
            }
            finally
            {
                _httpClient.Dispose();
            }
            return default;
        }
    }
}
