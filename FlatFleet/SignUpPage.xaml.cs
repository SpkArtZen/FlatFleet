using Firebase.Auth.Providers;
using Firebase.Auth;

namespace FlatFleet;

public partial class SignUpPage : ContentPage
{
    public SignUpPage(SignUpPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}