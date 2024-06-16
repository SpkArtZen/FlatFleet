using Firebase.Auth;
using FlatFleet.Features.Navigation;
using FlatFleet.Features.SignIn;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        private string _email;

        public string Email
        {
            get { return _email; }
            set 
            { 
                _email = value; 
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set 
            { 
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand SignInCommand { get; }
        public ICommand LoginWithGoogleCommand { get; }
        public ICommand LoginWithFacebookCommand { get; }
        public ICommand LoginWithAppleCommand { get; }
        public ICommand CreateAccountCommand { get; }
        public ICommand ForgotPasswordCommand { get; }
        // public ICommand SelectAccountCommand { get; }
        
        public SignInViewModel(FirebaseAuthClient authClient)
        {
            SignInCommand = new SignInCommand(this, authClient);
            LoginWithGoogleCommand = new Command(OnLoginWithGoogle);
            LoginWithFacebookCommand = new Command(OnLoginWithFacebook);
            LoginWithAppleCommand = new Command(OnLoginWithApple);
            CreateAccountCommand = new Command(OnCreateAccount);
            ForgotPasswordCommand = new Command(OnForgotPassword);
            // SelectAccountCommand = new Command(SelectAccountType);
        }

        public async void SelectAccountType()
        {
            await NavigationService.NavigateTo(typeof(SelectAccountTypePage));
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
            // await Shell.Current.GoToAsync("//SignUp");
            await NavigationService.NavigateTo(typeof(SignUpPage));
        }
        private async void OnForgotPassword()
        {
            await NavigationService.NavigateTo(typeof(RecoverPasswordPage));
        }
    }
}
