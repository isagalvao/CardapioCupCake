using CardapioCupCake.Core.Models;
using CardapioCupCake.Core.Service;
using CardapioCupCake.Core.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioCupCake.Core.ViewModel
{
    public partial class ProfileViewModel : ObservableObject
    {
        ListCupCakeRepository listCupCakeRepository;

        [ObservableProperty]
        private CadastroModel userProfile;

        [ObservableProperty]
        private bool isEditing = false;

        [ObservableProperty]
        private string profileImageUrl = "perfil.png";

        public ProfileViewModel(CadastroModel initialProfile)
        {
            UserProfile = initialProfile;
            listCupCakeRepository = listCupCakeRepository;
        }

        // Construtor sem parâmetros para Design Time
        public ProfileViewModel() : this(new CadastroModel
        {
            Nome = "Fulano de Tal",
            Email = "fulano@exemplo.com",
            Endereco = "Rua Principal, 100",
            Telefone = "41998877665",
            Senha = "senhaficticia"
        })
        { }
        public async void LoadUser(int Id)
        {
            //UserProfile = listCupCakeRepository.GetById(Id).Clone();

            //OnPropertyChanged(nameof(User));
        }

        [RelayCommand]
        public async Task Update()
        {

            if (await listCupCakeRepository.ValidateUserAsync(UserProfile))
            {
                listCupCakeRepository.UpdateUser(UserProfile);
                await Shell.Current.DisplayAlert("Sucesso!", "Perfil atualizado com sucesso.", "OK");
                await Shell.Current.CurrentPage.Navigation.PushAsync(new CardapioPage(new CardapioViewModel()));
            }
        }


        [RelayCommand]
        private async Task SelectPhoto()
        {
            // CORREÇÃO: Usar IsCaptureSupported para verificar suporte à captura de mídia
            if (MediaPicker.IsCaptureSupported)
            {
                var result = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Selecione a foto de perfil"
                });

                if (result != null)
                {
                    ProfileImageUrl = result.FullPath;
                    await Application.Current.MainPage.DisplayAlert("Foto Selecionada", $"Foto pronta para upload: {result.FileName}", "OK");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Seleção de mídia não suportada neste dispositivo.", "OK");
            }
        }
    }
}