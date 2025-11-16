using CardapioCupCake.Core.Models;
using CardapioCupCake.Core.View;
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
    public partial class CardapioViewModel : BaseViewModel
    {
        private int _cartCount;
        public int CartCount
        {
            get => _cartCount;
            set => SetProperty(ref _cartCount, value);
        }

        private CupcakeModel _selectedItem;
        public CupcakeModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<CupcakeModel> Cupcakes { get; set; }

        public ICommand OpenMenuCommand { get; }
        public ICommand OpenCartCommand { get; }
        public ICommand AddToCartCommand { get; }

        public CardapioViewModel()
        {
            OpenMenuCommand = new Command(OpenMenu);
            OpenCartCommand = new Command(OpenCart);
            AddToCartCommand = new Command<CupcakeModel>(AddToCart);

            Cupcakes = new ObservableCollection<CupcakeModel>
            {
                new CupcakeModel {Id=1, Name = "Cupcake de Chocolate", Price = 8, Image = "baunilha" },
                new CupcakeModel {Id=2, Name = "Cupcake de Morango", Price = 9, Image = "baunilha" },
                new CupcakeModel {Id=3, Name = "Cupcake de Baunilha", Price = 7, Image = "baunilha" },
                new CupcakeModel {Id=4, Name = "Cupcake Red Velvet", Price = 10, Image = "baunilha" },
                new CupcakeModel {Id=5, Name = "Cupcake Red Velvet", Price = 10, Image = "baunilha" },
                new CupcakeModel {Id=6, Name = "Cupcake Red Velvet", Price = 10, Image = "baunilha" },
                new CupcakeModel {Id=7, Name = "Cupcake Red Velvet", Price = 10, Image = "baunilha" },
                new CupcakeModel {Id=8, Name = "Cupcake Red Velvet", Price = 10, Image = "baunilha" },
            };
        }

        [RelayCommand]
        public async Task EditCupCake(CupcakeModel cupcake)
        {
            if (cupcake != null)
            {
                await Shell.Current.CurrentPage.Navigation.PushAsync(new CupCakeDetalhesPage(new CupcakeDetailViewModel(cupcake)), false);

            }
        }

        private void OpenMenu()
        {
            Application.Current.MainPage.DisplayAlert("Menu", "Abrir menu lateral", "OK");
        }

        private void OpenCart()
        {
            Application.Current.MainPage.DisplayAlert("Carrinho", $"Você tem {CartCount} itens no carrinho", "OK");
        }

        private void AddToCart(CupcakeModel cupcake)
        {
            CartCount++;
            Application.Current.MainPage.DisplayAlert("Carrinho", $"{cupcake.Name} adicionado ao carrinho!", "OK");
        }
    }
}
