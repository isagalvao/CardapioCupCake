using CardapioCupCake.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CardapioCupCake.Core.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public Command LoginCommand { get; }

        public MainViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked()
        {
            if (Email == "anneb@gmail.com" && Password == "1234")
                await Shell.Current.DisplayAlert("Login", "Login realizado com sucesso!", "OK");
            else
                await Shell.Current.DisplayAlert("Erro", "Usuário ou senha inválidos.", "OK");
        }
        
    }
}
