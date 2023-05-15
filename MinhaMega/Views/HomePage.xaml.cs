using CommunityToolkit.Mvvm.Input;
using MinhaMega.ViewModels;

namespace MinhaMega.Views;

public partial class HomePage : ContentPage
{
    public HomePage(HomePageViewModel homePageViewModel)
	{
		InitializeComponent();
		BindingContext = homePageViewModel;
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}