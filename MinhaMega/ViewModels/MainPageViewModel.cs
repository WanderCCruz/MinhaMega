using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MinhaMega.Api;

namespace MinhaMega.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly ILoteriaApi<Models.MegaSena> _api;
        Models.MegaSena result;
        [ObservableProperty]
        bool carregando;

        public MainPageViewModel(ILoteriaApi<Models.MegaSena> api)
        {
            _api = api;
        }
        [RelayCommand]
        async Task ParaMainPage()
        {
            await Shell.Current.GoToAsync(nameof(Views.MegaSena));
        }
        [RelayCommand]
        async Task BuscaMegaSena()
        {
            Carregando = true;
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                result = await _api.Concurso(nameof(Models.MegaSena), null);
            else
            {
                await Shell.Current.DisplayAlert("Atenção", "Verifique se sua internet esta funcionando !!!", "OK");
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(Views.MegaSena)}", new Dictionary<string, object>
            {
                ["ResultadoMega"] = result
            });
            Carregando = false;
        }
    }
}

