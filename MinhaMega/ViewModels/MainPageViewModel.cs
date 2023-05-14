using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MinhaMega.Api;
using MinhaMega.Models;
using MinhaMega.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MinhaMega.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly ILoteriaApi _api;
        public string result;

        public MainPageViewModel(ILoteriaApi api)
        {
            _api = api;
        }
        MegaSena megaSena { get; set; }
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
            var options = new JsonSerializerOptions
            {
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            megaSena = JsonSerializer.Deserialize<MegaSena>(result,options);
            await Shell.Current.DisplayAlert("teste",result,"ok");
            return result;
        }
    }
}

