using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using MinhaMega.Api;
using MinhaMega.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaMega.ViewModels
{
    [QueryProperty(nameof(ResultadoMega), nameof(ResultadoMega))]
    public partial class HomePageViewModel : ObservableObject
    {
        private readonly ILoteriaApi<MegaSena> _api;

        public HomePageViewModel(ILoteriaApi<MegaSena> api)
        {
            _api = api;
        }

        [RelayCommand]
        private async Task Voltar()
        {
            await Shell.Current.GoToAsync("..");
        }
        [ObservableProperty]
        MegaSena resultadoMega;

        [RelayCommand]
        async Task BuscaConcurso(string concurso)
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                ResultadoMega = await _api.Concurso(nameof(MegaSena).ToLower(), (Convert.ToInt32(concurso)));
            else
            {
                await Shell.Current.DisplayAlert("Atenção", "Verifique se sua internet esta funcionando !!!", "OK");
                return;
            }
        }
    }
}
