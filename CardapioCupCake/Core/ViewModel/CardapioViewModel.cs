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
    public class CardapioViewModel : BaseViewModel
    {
        private int _cartCount;
        public int CartCount
        {
            get => _cartCount;
            set => SetProperty(ref _cartCount, value);
        }

        public ObservableCollection<Cupcake> Cupcakes { get; set; }

        public ICommand OpenMenuCommand { get; }
        public ICommand OpenCartCommand { get; }
        public ICommand AddToCartCommand { get; }

        public CardapioViewModel()
        {
            // Comandos
            OpenMenuCommand = new Command(OpenMenu);
            OpenCartCommand = new Command(OpenCart);
            AddToCartCommand = new Command<Cupcake>(AddToCart);

            // Lista de cupcakes
            Cupcakes = new ObservableCollection<Cupcake>
            {
                new Cupcake { Name = "Cupcake de Chocolate", Price = 8, Image = "baunilha" },
                new Cupcake { Name = "Cupcake de Morango", Price = 9, Image = "baunilha" },
                new Cupcake { Name = "Cupcake de Baunilha", Price = 7, Image = "baunilha" },
                new Cupcake { Name = "Cupcake Red Velvet", Price = 10, Image = "baunilha" },
                new Cupcake { Name = "Cupcake Red Velvet", Price = 10, Image = "baunilha" },
                new Cupcake { Name = "Cupcake Red Velvet", Price = 10, Image = "baunilha" },
                new Cupcake { Name = "Cupcake Red Velvet", Price = 10, Image = "baunilha" },
                new Cupcake { Name = "Cupcake Red Velvet", Price = 10, Image = "baunilha" },
            };
        }

        private void OpenMenu()
        {
            Application.Current.MainPage.DisplayAlert("Menu", "Abrir menu lateral", "OK");
        }

        private void OpenCart()
        {
            Application.Current.MainPage.DisplayAlert("Carrinho", $"Você tem {CartCount} itens no carrinho", "OK");
        }

        private void AddToCart(Cupcake cupcake)
        {
            CartCount++;
            Application.Current.MainPage.DisplayAlert("Carrinho", $"{cupcake.Name} adicionado ao carrinho!", "OK");
        }
    }
}
