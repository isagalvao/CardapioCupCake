using CardapioCupCake.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CardapioCupCake.Core.Service
{
    public partial class ListCupCakeRepository
    {
        public ObservableCollection<CupcakeModel> Cupcakes { get; } = new ObservableCollection<CupcakeModel>();
        public ObservableCollection<CadastroModel> User { get; } = new ObservableCollection<CadastroModel>();

        public ListCupCakeRepository()
        {

        }
        public void AddCupcakesCarrinho(CupcakeModel cupcake)
        {
            if (cupcake != null)
            {
                cupcake.Id = Cupcakes.Count + 1;
                Cupcakes.Add(cupcake);
            }
        }
        public void AddCupcakesCarrinho(CadastroModel user)
        {
            if (user != null)
            {
                user.Id = User.Count + 1;
                User.Add(user);
            }
        }
        public List<CupcakeModel> GetAll()
        {
            try
            {
                return Cupcakes.ToList();
            }
            catch (Exception)
            {
                return new List<CupcakeModel>();
            }
        }
        public void UpdateUser(CadastroModel user)
        {
            var index = User.IndexOf(User.FirstOrDefault(u => u.Id == user.Id));
            if (index >= 0)
            {
                User[index] = user;
            }
        }

        public async Task<bool> ValidateUserAsync(CadastroModel user)
        {
            if (string.IsNullOrWhiteSpace(user.Nome))
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Nome é obrigatório.", "OK");
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.Telefone) || !IsValidPhoneNumber(user.Telefone))
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Número de telefone inválido.", "OK");
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                await Shell.Current.DisplayAlert("Erro!", "Por favor, preencha o e-mail.", "OK");
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.Endereco))
            {
                await Shell.Current.DisplayAlert("Erro!", "Por favor, preencha o endereço.", "OK");
                return false;
            }

            if (string.IsNullOrWhiteSpace(user.Senha) || !IsValidCPF(user.Senha))
            {
                await App.Current.MainPage.DisplayAlert("Erro", "CPF inválido.", "OK");
                return false;
            }

            return true;
        }

        private bool IsValidPhoneNumber(string number)
        {
            var regex = new Regex(@"^\(\d{2}\) \d{4,5}-\d{4}$");
            return regex.IsMatch(number);
        }

        private bool IsValidCPF(string cpf)
        {
            return cpf.Length == 14 && cpf[3] == '.' && cpf[7] == '.' && cpf[11] == '-';
        }
    }
}
