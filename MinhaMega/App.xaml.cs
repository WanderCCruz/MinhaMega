using MinhaMega.ViewModels;
using MinhaMega.Views;

namespace MinhaMega;

public partial class App : Application
{
    public App()
	{
		InitializeComponent();
		MainPage = new AppShell();

		Routing.RegisterRoute(nameof(HomePage),typeof(HomePage));
	}
}
