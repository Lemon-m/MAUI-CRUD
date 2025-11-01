using CommunityToolkit.Maui;
using CRUD;
using MAUI_CRUD.ViewModels;
#if ANDROID
using MAUI_CRUD.Platforms.Android.Handlers;
#endif
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace MAUI_CRUD
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureMauiHandlers(handlers =>
                {
                    #if ANDROID
                    handlers.AddHandler(typeof(Button), typeof(RippleButtonHandler));
                    #endif
                });

            builder.Services.AddSingleton<ObservableCollection<Product>>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();

            builder.Services.AddTransient<AddPage>();
            builder.Services.AddTransient<AddPageViewModel>();

            builder.Services.AddTransient<EditPage>();
            builder.Services.AddTransient<EditPageViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();
            return app;
        }
    }
}
