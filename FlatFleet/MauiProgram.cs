using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace FlatFleet
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
                    fonts.AddFont("SFProText-Regular.ttf", "SFProText-Regular");
                    fonts.AddFont("SFProText-Semibold.ttf", "SFProText-Semibold");
                    fonts.AddFont("SFProText-Bold.ttf", "SFProText-Bold");
                    fonts.AddFont("SFProText-BoldItalic.ttf", "SFProText-BoldItalic");
                    fonts.AddFont("SFProText-Heavy.ttf", "SFProText-HeavyItalic");
                    fonts.AddFont("SFProText-Light.ttf", "SFProText-Light");
                    fonts.AddFont("SFProText-LightItalic.ttf", "SFProText-LightItalic");
                    fonts.AddFont("SFProText-Medium.ttf", "SFProText-Medium");
                });

#if DEBUG
            object value = builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
