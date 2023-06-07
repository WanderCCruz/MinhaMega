using MinhaMega.ViewModels;

namespace MinhaMega.Views;

public partial class MegaSena : ContentPage
{
    public MegaSena(MegaSenaViewModel megaSenaViewModel)
	{
        InitializeComponent();
		BindingContext = megaSenaViewModel;
	}
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}