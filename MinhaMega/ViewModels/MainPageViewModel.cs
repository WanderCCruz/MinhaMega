using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MinhaMega.Api;
using MinhaMega.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaMega.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly ILoteriaApi _api;
        [ObservableProperty]
        public string result;
        [ObservableProperty]
        public string text;

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
        async Task<string> MegaSena()
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                result = await _api.Concurso(2590);
            await Shell.Current.DisplayAlert("teste",result,"ok");
            return result;
        }
    }
}

