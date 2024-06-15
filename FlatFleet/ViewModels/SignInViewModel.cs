using Navigation;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class SignInViewModel
    {
        public ICommand LoginWithGoogleCommand { get; }
        public ICommand LoginWithFacebookCommand { get; }
        public ICommand LoginWithAppleCommand { get; }
        public ICommand CreateAccountCommand { get; }
        public ICommand ForgotPasswordCommand { get; }
        public SignInViewModel()
        {
            LoginWithGoogleCommand = new Command(OnLoginWithGoogle);
            LoginWithFacebookCommand = new Command(OnLoginWithFacebook);
            LoginWithAppleCommand = new Command(OnLoginWithApple);
            CreateAccountCommand = new Command(OnCreateAccount);
            ForgotPasswordCommand = new Command(OnForgotPassword);
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
        private async void OnForgotPassword()
        {
            await NavigationService.NavigateTo(typeof(RecoverPasswordPage));
        }
    }
}
