using CardapioCupCake.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioCupCake.Core.ViewModel
{
    public partial class CarrinhoViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<CupcakeModel> items = new ObservableCollection<CupcakeModel>();

        [ObservableProperty]
        private CadastroModel customerInfo;

        [ObservableProperty]
        private double deliveryFee = 5.00;
        public string Name { get; set; }
        public double Price { get; set; } 
        public int Quantity { get; set; }
        public double TotalPrice => Price * Quantity;


        // Propriedades formatadas para Binding no XAML
        public string DisplaySubtotal => TotalPrice.ToString("C2");
        public string DisplayDeliveryFee => DeliveryFee.ToString("C2");
        public CarrinhoViewModel(List<CupcakeModel> cartItems, CadastroModel userInfo)
        {
            CustomerInfo = userInfo;
            foreach (var item in cartItems)
            {
                Items.Add(item);
            }
            UpdateTotals();
        }
        public CarrinhoViewModel()
        {
            LoadMockData();
        }
      private void LoadMockData()
{
    CustomerInfo = new CadastroModel
    {
        Nome = "Fulano de Tal",
    };

    var mockOrderItems = new List<CupcakeModel>
    {
        // ATRIBUIÇÃO CORRETA:
        new CupcakeModel {
            Name = "Cupcake de Chocolate",
            Price = 8.00,  
            // TotalPrice (16.00) será CALCULADO automaticamente!
        }, 
        new CupcakeModel { 
            Name = "Cupcake de Baunilha", 
            Price = 7.00,  
            // TotalPrice (7.00) será CALCULADO automaticamente!
        }   
    };

    foreach (var item in mockOrderItems)
    {
        Items.Add(item);
    }

    UpdateTotals();
}
        // Método para recalcular e notificar a UI
        private void UpdateTotals()
        {
            OnPropertyChanged(nameof(DisplaySubtotal));
            OnPropertyChanged(nameof(DisplayDeliveryFee));
            OnPropertyChanged(nameof(TotalPrice));
        }

        [RelayCommand]
        private async Task FinalizeOrder()
        {
            // Lógica para enviar o pedido ao servidor

            await Application.Current.MainPage.DisplayAlert("Pedido Enviado",
                $"O total de {DisplaySubtotal} foi finalizado. Enviando para o endereço: {CustomerInfo.Endereco}", "OK");
        }
    }
}
