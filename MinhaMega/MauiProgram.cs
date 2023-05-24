using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MinhaMega.Api;
using MinhaMega.ViewModels;
using MinhaMega.Views;

namespace MinhaMega;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<HomePageViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();

		builder.Services.AddTransient<ILoteriaApi,LoteriaApi>();
		


#if DEBUG
        builder.Logging.AddDebug();
#endif

		builder.Services.AddHttpClient("",HttpClient => HttpClient.BaseAddress = 
		new Uri("https://servicebus2.caixa.gov.br/portaldeloterias/api/megasena/2592")).ConfigurePrimaryHttpMessageHandler(() =>
        {
            return new HttpClientHandler
            {
                AllowAutoRedirect = false,
                UseDefaultCredentials = true,
                ServerCertificateCustomValidationCallback =
    (sender, cert, chain, sslPolicyErrors) => { return true; }
        };
        });
        builder.Services.AddSingleton<LoteriaApi>();
        return builder.Build();

	}
}
