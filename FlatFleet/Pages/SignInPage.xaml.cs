using Firebase.Auth.Providers;
using Firebase.Auth;
using FlatFleet.ViewModels;
#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Android.Graphics;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Handlers;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Content.Res;

#endif
namespace FlatFleet.Pages;

public partial class SignInPage : ContentPage
{
    public SignInPage(SignInPageViewModel viewModel)
    {
        InitializeComponent(); 
        NoUnderline();
        BindingContext = viewModel;
    }
    private void NoUnderline()
    {
#if ANDROID
    Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
    {
        if (handler.PlatformView is AndroidX.AppCompat.Widget.AppCompatEditText editText)
        {
            if (view == emailEntry || view == passwordEntry)
            {
                // «м≥на underline на прозорий
                editText.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
            }
        }
    });
#endif
    }

}

