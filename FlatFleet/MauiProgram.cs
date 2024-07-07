using CommunityToolkit.Maui;
using Camera.MAUI;
using Firebase.Auth;
using Firebase.Auth.Providers;
using FlatFleet.Pages;
using FlatFleet.ViewModels;
using Microsoft.Extensions.Logging;
#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Android.Graphics;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Handlers;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Content.Res;

#endif
using Firebase.Storage;
using FlatFleet.Models.Users;
using Google.Cloud.Firestore;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Google.Cloud.Firestore.V1;
using FlatFleet.Features.Services;
using Microsoft.Maui.Controls.PlatformConfiguration;

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
                .UseMauiMaps()
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
            builder.AddAppSetting();

            string? firebaseApiKey = builder.Configuration.GetValue<string>("FIREBASE_API_KEY");
            string? firebaseAuthDomain = builder.Configuration.GetValue<string>("FIREBASE_AUTH_DOMAIN");
            string? firebaseStorageDomain = builder.Configuration.GetValue<string>("FIREBASE_STORAGE_DOMAIN");

            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = firebaseApiKey,
                AuthDomain = firebaseAuthDomain,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            }));
            builder.Services.AddSingleton<FirebaseStorage>(s => new FirebaseStorage(firebaseStorageDomain));
            builder.Services.AddSingleton<CurrentUserStore>();

            // TODO: перенести ID в окреме місце (клас або json файл)
            builder.Services.AddSingleton<FirestoreDb>(s => initFirestore().Result);

            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<MainPage>();

            builder.Services.AddTransient<GetStartedViewModel>();
            builder.Services.AddTransient<GetStartedPage>();

            builder.Services.AddTransient<SignUpPageViewModel>();
            builder.Services.AddTransient<SignUpPage>();
            builder.Services.AddTransient<DbService>();

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

            builder.Services.AddTransient<StorageService>();

            builder.Services.AddTransient<DoubtPageViewModel>();
            builder.Services.AddTransient<DoubtPage>();

            builder.Services.AddTransient<HouseCommitteePageViewModel>();
            builder.Services.AddTransient<HouseCommitteePage>();

            builder.Services.AddTransient<TenantOfHousePageViewModel>();
            builder.Services.AddTransient<TenantOfHousePage>();

            builder.Services.AddTransient<AccountDashboardPageViewModel>();
            builder.Services.AddTransient<AccountDashboardPage>();

            builder.Services.AddTransient<ConfirmAdressOnMapPage>();
            // Реєстрація ViewModel та ILogger
            builder.Services.AddSingleton<ConfirmAdressOnMapPageViewModel>();
            builder.Services.AddSingleton<ConfirmAdressOnMapPage>();
            builder.Services.AddLogging();

            builder.Services.AddTransient<ConfirmAdressOnMapPageViewModel>();
#if DEBUG
            object value = builder.Logging.AddDebug();
#endif
#if ANDROID
Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) => 
{
    Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
    {
        if (handler.PlatformView is AndroidX.AppCompat.Widget.AppCompatEditText editText)
        {
            // Зміна underline на прозорий
            editText.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
        }
    });
});
#endif


            return builder.Build();
        }

        public static async Task<FirestoreDb> initFirestore()
        {
            try
            {
                var stream = await FileSystem.OpenAppPackageFileAsync("project_credentials.json");
                var reader = new StreamReader(stream);
                var contents = reader.ReadToEnd();

                FirestoreClientBuilder fbc = new FirestoreClientBuilder { JsonCredentials = contents };
                return FirestoreDb.Create("flat-fleet", fbc.Build());
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void AddAppSetting(this MauiAppBuilder builder)
        {
            using Stream? stream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream("FlatFleet.appsettings.json");

            if (stream != null)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();
                builder.Configuration.AddConfiguration(configuration);
            }
        }
    }
}
