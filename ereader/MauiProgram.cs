using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using ereader.Services;

namespace ereader
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
                });

            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddSingleton<FileService>();
            builder.Services.AddSingleton<BookService>();

            builder.Services.AddSingleton<Views.HomePage>();
            builder.Services.AddSingleton<Views.LibraryPage>();
            builder.Services.AddSingleton<Views.ReaderPage>();
            builder.Services.AddSingleton<Views.SettingsPage>();

            builder.Services.AddTransient<ViewModels.HomeViewModel>();
            builder.Services.AddTransient<ViewModels.LibraryViewModel>();
            builder.Services.AddTransient<ViewModels.ReaderViewModel>();
            builder.Services.AddTransient<ViewModels.SettingsViewModel>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
