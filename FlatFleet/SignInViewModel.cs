using System.Windows.Input;
using Microsoft.Maui.Controls;
using Navigation;

namespace FlatFleet
{
    public class SignInViewModel : BindableObject
    {
        public ICommand LoginWithGoogleCommand { get; }
        public ICommand LoginWithFacebookCommand { get; }
        public ICommand LoginWithAppleCommand { get; }
        public ICommand CreateAccountCommand { get; }

        public SignInViewModel()
        {
            LoginWithGoogleCommand = new Command(OnLoginWithGoogle);
            LoginWithFacebookCommand = new Command(OnLoginWithFacebook);
            LoginWithAppleCommand = new Command(OnLoginWithApple);
            CreateAccountCommand = new Command(OnCreateAccount);
        }

        private async void OnLoginWithGoogle()
        {
            await NavigationService.NavigateTo(typeof(MainPage));
        }

        private async void OnLoginWithFacebook()
        {
            await NavigationService.NavigateTo(typeof(MainPage));
        }

        private async void OnLoginWithApple()
        {
            await NavigationService.NavigateTo(typeof(MainPage));
        }

        private async void OnCreateAccount()
        {
            await NavigationService.NavigateTo(typeof(CreateAnAccountPage));
        }
    }
}
