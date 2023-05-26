using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
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

        [RelayCommand]
        private async Task Voltar()
        {
            await Shell.Current.GoToAsync("..");
        }
        [ObservableProperty]
        MegaSena resultadoMega;
    }
}
