using CardapioCupCake.Core.ViewModel;

namespace CardapioCupCake.Core.View;

public partial class ProfilePage : ContentPage
{
    ProfileViewModel ViewModel;
    public ProfilePage(ProfileViewModel vm)
	{
		InitializeComponent();
        BindingContext = ViewModel = vm;
    }
}