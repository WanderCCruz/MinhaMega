using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MinhaMega.Api;
using MinhaMega.Models;
using MinhaMega.Views;
using System.Text.Json;

namespace MinhaMega.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly ILoteriaApi _api;
        string result;

        public MainPageViewModel(ILoteriaApi api)
        {
            _api = api;
        }
        [RelayCommand]
        async Task ParaMainPage()
        {
            await Shell.Current.GoToAsync(nameof(HomePage));
        }
        [RelayCommand]
        async Task MegaSena()
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                result = await _api.Concurso(null);
            if(result.Length == 0)
            {
                await Shell.Current.DisplayAlert("Atenção","Houve algum problema com a solicitação, tente mais tarde","OK");
                return ;
            }
            var options = new JsonSerializerOptions
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            var resultadoMega = JsonSerializer.Deserialize<MegaSena>(result,options);
            
             await Shell.Current.GoToAsync($"{nameof(HomePage)}", new Dictionary<string, object>
             {
                 ["ResultadoMega"] = resultadoMega
             });
        }
    }
}

