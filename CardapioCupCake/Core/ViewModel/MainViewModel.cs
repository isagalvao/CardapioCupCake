using CardapioCupCake.Core.Models;
using CardapioCupCake.Core.Service;
using CardapioCupCake.Core.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CardapioCupCake.Core.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        private readonly HubService _hubService;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string senha;

        [ObservableProperty]
        private string mensagemErro;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private string errorMessage;
        public IAsyncRelayCommand LoginCommand { get; }

        public MainViewModel()
        {
            _hubService = new HubService();
            LoginCommand = new AsyncRelayCommand(OnLoginClicked);
        }

        private async Task OnLoginClicked()
        {
            IsBusy = true;
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Senha))
            {
                await Shell.Current.DisplayAlert("Aviso!", "Por favor, preencha o e-mail e a senha.", "OK");
                IsBusy = false;
                return;
            }

            try
            {
                //var sucesso = await _hubService.LoginAsync(Email, Senha);
                //if (sucesso)
                //{
                if (Email == "admin@teste.com" && senha == "123456")
                {
                    await Shell.Current.CurrentPage.Navigation.PushAsync(new CardapioPage(new CardapioViewModel()));
                }
                else
                {
                    await Shell.Current.DisplayAlert("Aviso!", "E-mail ou senha inválidos. Tente novamente.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Aviso!", $"Ocorreu um erro: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false; // Esconde o carregamento
            }

            IsBusy = false;
        }
    }
}
