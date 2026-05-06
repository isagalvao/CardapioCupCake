using CardapioCupCake.Core.Models;
using CardapioCupCake.Core.ViewModel;

namespace CardapioCupCake.Core.View;

public partial class CupCakeDetalhesPage : ContentPage
{
	CupcakeDetailViewModel viewModel;

    public CupCakeDetalhesPage(CupcakeDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = viewModel = vm;	
    }
}