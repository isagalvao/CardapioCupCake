using CardapioCupCake.Core.Models;
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
        // Propriedade para guardar os dados do usuário, que será ligada na View
        [ObservableProperty]
        private CadastroModel userProfile;

        // Propriedade para controlar se os campos estão habilitados para edição
        [ObservableProperty]
        private bool isEditing = false;

        // Propriedade para a imagem do perfil (URL ou caminho local)
        [ObservableProperty]
        private string profileImageUrl = "default_profile.png";

        public ProfileViewModel(CadastroModel initialProfile)
        {
            UserProfile = initialProfile;

            // Simular uma imagem salva (se tiver)
            // if (!string.IsNullOrEmpty(initialProfile.ProfileImage))
            // {
            //      ProfileImageUrl = initialProfile.ProfileImage;
            // }
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


        // --- COMMANDS ---

        [RelayCommand]
        private void ToggleEdit()
        {
            // Inverte o estado de edição
            IsEditing = !IsEditing;

            if (!IsEditing)
            {
                // Se saiu do modo de edição, tentamos salvar (ou confirmar)
                // Aqui você chamaria o serviço de API para salvar UserProfile
                SaveProfileChanges();
            }
        }

        private void SaveProfileChanges()
        {
            // Lógica real de salvamento (Ex: Chamar API)
            // Exemplo: _userService.UpdateProfile(UserProfile);

            // Apenas para feedback visual
            Application.Current.MainPage.DisplayAlert("Sucesso", "Perfil atualizado com sucesso!", "OK");
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