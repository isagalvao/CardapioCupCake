using CardapioCupCake.Core.Models;
using CardapioCupCake.Core.ViewModel;

namespace CardapioCupCake.Core.View;

public partial class CadastroPage : ContentPage
{
    CadastroViewModel ViewModel;
    public CadastroPage(CadastroViewModel vm)
	{
		InitializeComponent();
        BindingContext = ViewModel = vm;

    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current?.CurrentPage.Navigation.RemovePage(this);
    }
}