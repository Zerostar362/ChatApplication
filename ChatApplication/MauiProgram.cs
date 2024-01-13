using ChatApplication.Code.Broker;
using ChatApplication.ViewModels;
using Microsoft.Extensions.Logging;

namespace ChatApplication
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<IBroker, SimpleBroker>();
            builder.Services.AddSingleton<SettingsViewModel>();
            builder.Services.AddTransient<ChatViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
