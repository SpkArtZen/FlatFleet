using CommunityToolkit.Maui;
using Camera.MAUI;
using Firebase.Auth;
using Firebase.Auth.Providers;
using FlatFleet.Pages;
using FlatFleet.ViewModels;
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
                .UseMauiCameraView()
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

            // КОД НИЖЧЕ - НЕ ЧІПАТИ! ВІН ПОТРІБЕН ДЛЯ КОРЕКТНОГО СТВОРЕННЯ СТОРІНОК ЧЕРЕЗ DI
            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyBGFWSnUtDTw0z508FPy5f_z8Z2aFeTw04",
                AuthDomain = "flat-fleet.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            }));
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();

            builder.Services.AddTransient<GetStartedViewModel>();
            builder.Services.AddTransient<GetStartedPage>();

            builder.Services.AddTransient<SignUpPageViewModel>();
            builder.Services.AddTransient<SignUpPage>();

            builder.Services.AddTransient<PrivacyPolicyViewModel>();
            builder.Services.AddTransient<PrivacyPolicyPage>();

            builder.Services.AddTransient<TermsOfServiceViewModel>();
            builder.Services.AddTransient<TermsOfServicePage>();

            builder.Services.AddTransient<SignInPageViewModel>();
            builder.Services.AddTransient<SignInPage>();

            builder.Services.AddTransient<RecoverPasswordPageViewModel>();
            builder.Services.AddTransient<RecoverPasswordPage>();

            builder.Services.AddTransient<VerifyEmailPageViewModel>();
            builder.Services.AddTransient<VerifyEmailPage>();

            builder.Services.AddTransient<SelectAccountTypePageViewModel>();
            builder.Services.AddTransient<SelectAccountTypePage>();

            builder.Services.AddTransient<ManagementCompanyViewModel>();
            builder.Services.AddTransient<ManagementCompanyPage>();

            builder.Services.AddTransient<UploadFilesViewModel>();
            builder.Services.AddTransient<UploadFilesPage>();
#if DEBUG
            object value = builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
