using CardapioCupCake.Core.View;
using CardapioCupCake.Core.ViewModel;
using CommunityToolkit.Maui;
using Microsoft.Maui.Handlers;
using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.Logging;

namespace CardapioCupCake
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkitCore()
                .UseMauiCommunityToolkit(options =>
                 {

                     options.SetShouldEnableSnackbarOnWindows(true);
                     options.SetShouldSuppressExceptionsInConverters(true);
                     options.SetShouldSuppressExceptionsInBehaviors(true);
                     options.SetShouldSuppressExceptionsInAnimations(true);
                 })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if ANDROID
EntryHandler.Mapper.AppendToMapping("ChangeUnderlineColor", (handler, view) =>
{
  handler.PlatformView.BackgroundTintList =
    Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
});
#endif

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddTransientWithShellRoute<MainPage, MainViewModel>(nameof(MainPage));
            builder.Services.AddTransientWithShellRoute<CardapioPage, CardapioViewModel>(nameof(CardapioPage));
            builder.Services.AddTransientWithShellRoute<CadastroPage, CadastroViewModel>(nameof(CadastroPage));
            builder.Services.AddTransientWithShellRoute<CarrinhoPage, CarrinhoViewModel>(nameof(CarrinhoPage));
            builder.Services.AddTransientWithShellRoute<ProfilePage, ProfileViewModel>(nameof(ProfilePage));

            return builder.Build();
        }
    }
}
