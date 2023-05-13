using CommunityToolkit.Mvvm.Input;
using MinhaMega.ViewModels;
using MinhaMega.Views;

namespace MinhaMega;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel mainPageViewModel)
    {
        InitializeComponent();
        BindingContext = mainPageViewModel;
    }
}

