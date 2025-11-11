using CardapioCupCake.Core.ViewModel;

namespace CardapioCupCake.Core.View;

public partial class CardapioPage : ContentPage
{
    CardapioViewModel ViewModel;
    public CardapioPage(CardapioViewModel vm)
	{
		InitializeComponent();
		BindingContext = ViewModel = vm;
	}
}