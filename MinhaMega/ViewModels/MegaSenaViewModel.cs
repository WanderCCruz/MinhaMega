using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Platform;
using MinhaMega.Api;
using MinhaMega.Models;

namespace MinhaMega.ViewModels
{
    [QueryProperty(nameof(ResultadoMega), nameof(ResultadoMega))]
    public partial class MegaSenaViewModel : ObservableObject
    {
        private readonly ILoteriaApi<MegaSena> _api;
        [ObservableProperty]
        bool carregando;

        public MegaSenaViewModel(ILoteriaApi<MegaSena> api)
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
            try
            {
                Carregando = true;
                if (concurso == null)
                    throw new IndexOutOfRangeException("Digite um numero de concurso");
#if ANDROID
                if(Platform.CurrentActivity.CurrentFocus != null)
                    Platform.CurrentActivity.HideKeyboard(Platform.CurrentActivity.CurrentFocus);
#endif
                if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
                {
                    var resul = await _api.Concurso(nameof(MegaSena), (concurso));
                    if (resul == null)
                        await Shell.Current.DisplayAlert("Atenção", "Concurso não encontrado !!!", "OK");
                    else ResultadoMega = resul;
                }
                else
                {
                    await Shell.Current.DisplayAlert("Atenção", "Verifique se sua internet esta funcionando !!!", "OK");
                    return;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                await Shell.Current.DisplayAlert("Atenção", $"{e.Message}", "OK");
                await Shell.Current.GoToAsync(nameof(MainPage));
            }
            catch (Exception e)
            {
                string msg = "Concurso não encontrado\n";
#if DEBUG
                msg += e.Message;
#endif
                await Shell.Current.DisplayAlert("Atenção", msg, "OK");
            }
            finally { Carregando = false; }
        }
    }
}
