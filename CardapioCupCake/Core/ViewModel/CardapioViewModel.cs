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
              new CupcakeModel {Id=1, Name = "Cupcake de Chocolate", Price = 8, Image = "chocolate", Descricao = "Um bolo fofo de chocolate amargo, coberto com ganache de chocolate cremoso e raspas de cacau." },
              new CupcakeModel {Id=2, Name = "Cupcake de Morango", Price = 9, Image = "morango", Descricao = "Massa de baunilha com pedaços de morango, recheado com geleia de morango caseira e cobertura de chantilly de morango." },
              new CupcakeModel {Id=3, Name = "Cupcake de Baunilha", Price = 7, Image = "baunilha", Descricao = "A receita original, com massa aerada de baunilha e uma suave cobertura de buttercream de baunilha." },
              new CupcakeModel {Id=4, Name = "Cupcake Red Velvet", Price = 10, Image = "velvet", Descricao = "O famoso bolo aveludado vermelho, com um toque suave de cacau, e a tradicional cobertura de cream cheese frosting." },
              new CupcakeModel {Id=5, Name = "Cupcake de Limão Siciliano", Price = 9, Image = "limao", Descricao = "Bolo com raspas e sumo de limão siciliano, com recheio ácido e doce, e cobertura de merengue suíço tostado." },
              new CupcakeModel {Id=6, Name = "Cupcake de Doce de Leite", Price = 11, Image = "doce", Descricao = "Massa úmida de coco, recheada com doce de leite argentino e finalizada com flocos de coco queimado." },
              new CupcakeModel {Id=7, Name = "Cupcake de Café e Caramelo Salgado", Price = 10, Image = "caramelo", Descricao = "Bolo de café intenso, coberto com um buttercream de caramelo salgado e um grão de café coberto com chocolate." },
              new CupcakeModel {Id=8, Name = "Cupcake de Cenoura", Price = 9, Image = "cenoura", Descricao = "Massa de cenoura com canela e nozes picadas, com cobertura densa e cremosa de cream cheese e um toque de especiarias." }
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
