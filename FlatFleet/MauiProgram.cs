﻿using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Logging;

namespace FlatFleet
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
                    fonts.AddFont("SFProText-Regular.ttf", "SFProText-Regular");
                    fonts.AddFont("SFProText-Semibold.ttf", "SFProText-Semibold");
                    fonts.AddFont("SFProText-Bold.ttf", "SFProText-Bold");
                    fonts.AddFont("SFProText-BoldItalic.ttf", "SFProText-BoldItalic");
                    fonts.AddFont("SFProText-Heavy.ttf", "SFProText-HeavyItalic");
                    fonts.AddFont("SFProText-Light.ttf", "SFProText-Light");
                    fonts.AddFont("SFProText-LightItalic.ttf", "SFProText-LightItalic");
                    fonts.AddFont("SFProText-Medium.ttf", "SFProText-Medium");
                });
            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyBGFWSnUtDTw0z508FPy5f_z8Z2aFeTw04",
                AuthDomain = "flat-fleet.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            }));

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
