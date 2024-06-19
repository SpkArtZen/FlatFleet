using CommunityToolkit.Maui;
using Camera.MAUI;
using Firebase.Auth;
using Firebase.Auth.Providers;
using FlatFleet.Pages;
using FlatFleet.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Firebase.Storage;
using FlatFleet.Models.Users;
using Google.Cloud.Firestore;

namespace FlatFleet
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string pathToCredentials = "./FlatFleet/Properties/project_credentials.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", pathToCredentials);

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCameraView()
                .ConfigureFonts(fonts =>
                {
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
            // TODO: перенести ці значення в окремий json файл
            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyBGFWSnUtDTw0z508FPy5f_z8Z2aFeTw04",
                AuthDomain = "flat-fleet.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            }));
            builder.Services.AddSingleton<FirebaseStorage>(s => new FirebaseStorage("flat-fleet.appspot.com"));
            builder.Services.AddSingleton<CurrentUserStore>();

            // TODO: перенести ID в окреме місце (клас або json файл)
            builder.Services.AddSingleton<FirestoreDb>(s => FirestoreDb.Create("flat-fleet"));
            
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

            builder.Services.AddTransient<DoubtPageViewModel>();
            builder.Services.AddTransient<DoubtPage>();

            builder.Services.AddTransient<HouseCommitteePageViewModel>();
            builder.Services.AddTransient<HouseCommitteePage>();

            builder.Services.AddTransient<TenantOfHousePageViewModel>();
            builder.Services.AddTransient<TenantOfHousePage>();
#if DEBUG
            object value = builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
