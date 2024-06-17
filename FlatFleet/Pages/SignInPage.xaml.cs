using Firebase.Auth.Providers;
using Firebase.Auth;
using FlatFleet.ViewModels;

namespace FlatFleet
{
    public partial class SignInPage : ContentPage
    {
        public SignInPage(SignInPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}

