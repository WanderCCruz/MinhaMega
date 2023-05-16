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
        [ObservableProperty]
        int test;

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
            Test = 50;
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                result = await _api.Concurso(2590);
            var options = new JsonSerializerOptions
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            var resultadoMega = JsonSerializer.Deserialize<MegaSena>(result,options);
            
             await Shell.Current.GoToAsync($"{nameof(HomePage)}?Test={Test}", new Dictionary<string, object>
             {
                 ["ResultadoMega"] = resultadoMega
             });
            //await Shell.Current.DisplayAlert("teste",result,"ok");
        }
    }
}

