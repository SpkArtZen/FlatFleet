using Firebase.Auth.Providers;
using Firebase.Auth;

namespace FlatFleet.Pages;

public partial class SignUpPage : ContentPage
{
    public SignUpPage(SignUpPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}