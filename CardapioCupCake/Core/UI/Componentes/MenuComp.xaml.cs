using CardapioCupCake.Core.View;
using CardapioCupCake.Core.ViewModel;

namespace CardapioCupCake.Core.UI.Componentes;

public partial class MenuComp : Grid
{
	public MenuComp()
	{
		InitializeComponent();
	}
    private async void OnHomeTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.CurrentPage.Navigation.PushAsync(new CardapioPage(new CardapioViewModel()));
    }
    private async void OnshoppingTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.CurrentPage.Navigation.PushAsync(new CarrinhoPage(new CarrinhoViewModel()));
    }

    private async void OnpersonTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.CurrentPage.Navigation.PushAsync(new CardapioPage(new CardapioViewModel()));
    }
}