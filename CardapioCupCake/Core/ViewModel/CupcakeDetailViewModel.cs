using CardapioCupCake.Core.Models;
using CardapioCupCake.Core.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardapioCupCake.Core.ViewModel
{
    public partial class CupcakeDetailViewModel : BaseViewModel
    {
        ListCupCakeRepository cupcakeRepository;    
        [ObservableProperty]
        private int cupcakeId;

        private CupcakeModel cupcake;
        public CupcakeModel Cupcake
        {
            get => cupcake;
            set => SetProperty(ref cupcake, value);
        }
        private int quantityText = 1;
        public int QuantityText
        {
            get => quantityText;
            set
            {
                if (SetProperty(ref quantity, value))
                {
                    UpdateTotalValue();
                }
            }
        }


        private int quantity = 1;
        public int Quantity
        {
            get => quantity;
            set
            {
                if (SetProperty(ref quantity, value))
                {
                    UpdateTotalValue();
                }
            }
        }

        private int menosQuantity = 1;
        public int MenosQuantity
        {
            get => menosQuantity;
            set
            {
                if (SetProperty(ref menosQuantity, value))
                {
                    DecreaseQuantity();
                }
            }
        }

        [ObservableProperty]
        private double totalValue;
        public CupcakeDetailViewModel(CupcakeModel cupcake)
        {
            Cupcake = cupcake;
            cupcakeRepository = new ListCupCakeRepository();
            UpdateTotalValue();
        }
        partial void OnCupcakeIdChanged(int value)
        {
            LoadCupcakeDetails(value);
        }

        private void UpdateTotalValue()
        {
            if (Cupcake != null)
            {
                TotalValue = (double)Quantity * Cupcake.Price;
            }
        }

        private void LoadCupcakeDetails(int id)
        {
            UpdateTotalValue();
        }

        [RelayCommand]
        private void IncreaseQuantity() 
        {
            Quantity++;
            OnPropertyChanged(nameof(Quantity));
            OnPropertyChanged(nameof(TotalValue));
        }

        [RelayCommand]
        private void DecreaseQuantity()         
        {
            if (Quantity > 1)
            {
                Quantity--;
                OnPropertyChanged(nameof(Quantity));
                OnPropertyChanged(nameof(TotalValue));
            }
        }

        [RelayCommand]
        private async Task AddToCart()
        {
            if (Cupcake != null && Quantity > 0)
            {
                cupcakeRepository.AddCupcakes(Cupcake);
                await Shell.Current.DisplayAlert("Adicionado!",
                    $"{Quantity} x {Cupcake.Name} adicionado(s) ao carrinho.",
                    "OK");

            }
        }
    }
}
