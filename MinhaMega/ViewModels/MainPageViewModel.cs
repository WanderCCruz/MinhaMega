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
        private readonly ILoteriaApi<MegaSena> _api;
        MegaSena result;

        public MainPageViewModel(ILoteriaApi<MegaSena> api)
        {
            _api = api;
        }
        [RelayCommand]
        async Task ParaMainPage()
        {
            await Shell.Current.GoToAsync(nameof(HomePage));
        }
        [RelayCommand]
        async Task BuscaMegaSena()
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                result = await _api.Concurso(nameof(MegaSena),null);
            else
            {
                await Shell.Current.DisplayAlert("Atenção", "Verifique se sua internet esta funcionando !!!", "OK");
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(HomePage)}", new Dictionary<string, object>
            {
                 ["ResultadoMega"] = result
            });
        }
    }
}

