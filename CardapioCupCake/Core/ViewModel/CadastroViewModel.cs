using CardapioCupCake.Core.Models;
using CardapioCupCake.Core.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CardapioCupCake.Core.ViewModel
{
    public partial class CadastroViewModel : BaseViewModel
    {
        private readonly HubService hubService;
        private CadastroModel usuario = new();

        public string Nome
        {
            get => usuario.Nome;
            set { usuario.Nome = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => usuario.Email;
            set { usuario.Email = value; OnPropertyChanged(); }
        }

        public string Senha
        {
            get => usuario.Senha;
            set { usuario.Senha = value; OnPropertyChanged(); }
        }

        public string Endereco
        {
            get =>  usuario.Endereco;
            set { usuario.Endereco = value; OnPropertyChanged(); }
        }

        public string Telefone
        {
            get => usuario.Telefone;
            set { usuario.Telefone = value; OnPropertyChanged(); }
        }

        private string mensagem;
        public string Mensagem
        {
            get => mensagem;
            set
            {
                mensagem = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsMensagemVisible));
            }
        }

        public bool IsMensagemVisible => !string.IsNullOrWhiteSpace(Mensagem);
        [ObservableProperty]
        private bool _isEmailValid = true;

        private string confirmarSenha; 
        public string ConfirmarSenha
        {
            get => confirmarSenha;
            set { confirmarSenha = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CadastrarCommand { get; }

        public CadastroViewModel()
        {
            hubService = hubService;
            CadastrarCommand = new RelayCommand(Cadastrar);
        }
        private void Cadastrar()
        {
            Mensagem = string.Empty;

            if (string.IsNullOrWhiteSpace(Nome) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Senha) ||
                string.IsNullOrWhiteSpace(ConfirmarSenha) ||
                string.IsNullOrWhiteSpace(Telefone))
            {
                Mensagem = "Preencha todos os campos obrigatórios!";
                return;
            }

            if (!IsEmailValid)
            {
                Mensagem = "O formato do E-mail é inválido. Por favor, verifique.";
                return;
            }

            string telefoneLimpo = Regex.Replace(Telefone ?? string.Empty, @"[^\d]", "");

            if (telefoneLimpo.Length < 10 || telefoneLimpo.Length > 11)
            {
                Mensagem = "Telefone incorreto. Deve conter 10 ou 11 dígitos (com DDD).";
                return;
            }

            if (Senha.Length < 8)
            {
                Mensagem = "A senha deve ter no mínimo 8 caracteres.";
                return;
            }

            if (Senha != ConfirmarSenha)
            {
                Mensagem = "As senhas digitadas não são iguais. Por favor, verifique.";
                return;
            }

             Task.Delay(2000);
            bool resultado = true;

            if (resultado)
            {
                Mensagem = "✅ Usuário cadastrado com sucesso!";

                 Shell.Current.GoToAsync(".."); // Ex: Navegar para a tela de Login ou Home.

                // Limpeza dos campos após o sucesso
                usuario = new CadastroModel();
                ConfirmarSenha = string.Empty;
                OnPropertyChanged(nameof(Nome));
                OnPropertyChanged(nameof(Email));
                OnPropertyChanged(nameof(Senha));
                OnPropertyChanged(nameof(Endereco));
                OnPropertyChanged(nameof(Telefone));
                OnPropertyChanged(nameof(ConfirmarSenha));
                return;
            }
            else
            {

                 Shell.Current.DisplayAlert("Aviso!", "Cadastro falhou. Este e-mail já está em uso.", "OK");
                return;
            }
        }


        private async Task CadastrarAsync()
        {
            /*IsBusy = true;*/ 
            try
            {
                Mensagem = string.Empty;

                if (string.IsNullOrWhiteSpace(Nome) ||
                    string.IsNullOrWhiteSpace(Email) ||
                    string.IsNullOrWhiteSpace(Senha) ||
                    string.IsNullOrWhiteSpace(ConfirmarSenha) ||
                    string.IsNullOrWhiteSpace(Telefone))
                {
                    Mensagem = "Preencha todos os campos obrigatórios!";
                    return;
                }

                string telefoneLimpo = Regex.Replace(Telefone ?? string.Empty, @"[^\d]", "");

                if (telefoneLimpo.Length < 10 || telefoneLimpo.Length > 11)
                {
                    Mensagem = "Telefone incorreto. Deve conter 10 ou 11 dígitos (com DDD).";
                    return;
                }

                if (Senha.Length < 8)
                {
                    Mensagem = "A senha deve ter no mínimo 8 caracteres.";
                    return;
                }

                if (Senha != ConfirmarSenha)
                {
                    Mensagem = "As senhas digitadas não são iguais. Por favor, verifique.";
                    return;
                }

                // --- INTEGRAÇÃO COM A API (POST) ---

                // Crio um objeto com os dados limpos para enviar
                var novoUsuario = new CadastroModel
                {
                    Nome = Nome,
                    Email = Email,
                    Senha = Senha, // A Senha deve ser hashada antes de ir para um banco de dados real.
                    Endereco = Endereco,
                    Telefone = telefoneLimpo // Envia o telefone limpo
                };

                //var resultado = await hubService.PostNovoCadastroAsync(novoUsuario);

                await Task.Delay(2000);
                bool resultado = true; 

                if (resultado)
                {
                    Mensagem = "✅ Usuário cadastrado com sucesso!";

                    await Shell.Current.GoToAsync(".."); // Ex: Navegar para a tela de Login ou Home.

                    // Limpeza dos campos após o sucesso
                    usuario = new CadastroModel();
                    ConfirmarSenha = string.Empty;
                    OnPropertyChanged(nameof(Nome));
                    OnPropertyChanged(nameof(Email));
                    OnPropertyChanged(nameof(Senha));
                    OnPropertyChanged(nameof(Endereco));
                    OnPropertyChanged(nameof(Telefone));
                    OnPropertyChanged(nameof(ConfirmarSenha));
                }
                else
                {

                    await Shell.Current.DisplayAlert("Aviso!", "Cadastro falhou. Este e-mail já está em uso.", "OK");

                }

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Aviso!", $"Ocorreu um erro: {ex.Message}", "OK");
            }
            finally
            {
                // Isso garante que o indicador de carregamento (IsBusy) seja sempre desativado.
                //IsBusy = false;
            }
        }
    }

}
