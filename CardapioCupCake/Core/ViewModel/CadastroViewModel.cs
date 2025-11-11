using CardapioCupCake.Core.Models;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CardapioCupCake.Core.ViewModel
{
    public class CadastroViewModel : BaseViewModel
    {
        private CadastroModel _usuario = new();
        private string _mensagem;

        public string Nome
        {
            get => _usuario.Nome;
            set { _usuario.Nome = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => _usuario.Email;
            set { _usuario.Email = value; OnPropertyChanged(); }
        }

        public string Senha
        {
            get => _usuario.Senha;
            set { _usuario.Senha = value; OnPropertyChanged(); }
        }

        public string Endereco
        {
            get => _usuario.Endereco;
            set { _usuario.Endereco = value; OnPropertyChanged(); }
        }

        public string Telefone
        {
            get => _usuario.Telefone;
            set { _usuario.Telefone = value; OnPropertyChanged(); }
        }

        public string Mensagem
        {
            get => _mensagem;
            set { _mensagem = value; OnPropertyChanged(); }
        }
        public ICommand CadastrarCommand { get; }

        public CadastroViewModel()
        {
            CadastrarCommand = new RelayCommand(Cadastrar);
        }
        private void Cadastrar()
        {
            if (string.IsNullOrWhiteSpace(Nome) ||
                string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Senha))
            {
                Mensagem = "Preencha todos os campos obrigatórios!";
                return;
            }


            Mensagem = "Usuário cadastrado com sucesso!";

            _usuario = new CadastroModel();
            OnPropertyChanged(nameof(Nome));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(Senha));
            OnPropertyChanged(nameof(Endereco));
            OnPropertyChanged(nameof(Telefone));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
