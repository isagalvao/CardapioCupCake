using CardapioCupCake.Core.View;
using CardapioCupCake.Core.ViewModel;

namespace CardapioCupCake
{
    public partial class MainPage : ContentPage
    {
        MainViewModel ViewModel;
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = ViewModel = vm;
        }
        private async void OnCadastroClicked(object sender, EventArgs e)
        {
            await Shell.Current.CurrentPage.Navigation.PushAsync(new CadastroPage(new CadastroViewModel()));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.CurrentPage.Navigation.PushAsync(new CardapioPage(new CardapioViewModel()));
        }
    }
}
