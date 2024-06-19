using Firebase.Auth;
using FlatFleet.Features.Navigation;
using FlatFleet.Features.SignIn;
using FlatFleet.Models.Users;
using FlatFleet.Pages;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class SignInPageViewModel : ViewModelBase
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

        private bool _isPasswordHidden = true;
        public bool IsPasswordHidden
        {
            get { return _isPasswordHidden; }
            set
            {
                if (_isPasswordHidden != value)
                {
                    _isPasswordHidden = value;
                    OnPropertyChanged(nameof(IsPasswordHidden));
                }
            }
        }

        public ICommand SignInCommand { get; }
        public ICommand LoginWithGoogleCommand { get; }
        public ICommand LoginWithFacebookCommand { get; }
        public ICommand LoginWithAppleCommand { get; }
        public ICommand CreateAccountCommand { get; }
        public ICommand ForgotPasswordCommand { get; }

        public ICommand SwitchAppearanceOfPassword { get; }

        // public ICommand SelectAccountCommand { get; }
        
        public SignInPageViewModel(FirebaseAuthClient authClient, CurrentUserStore userStore)
        {
            SignInCommand = new SignInCommand(this, authClient, userStore);
            LoginWithGoogleCommand = new Command(OnLoginWithGoogle);
            LoginWithFacebookCommand = new Command(OnLoginWithFacebook);
            LoginWithAppleCommand = new Command(OnLoginWithApple);
            CreateAccountCommand = new Command(OnCreateAccount);
            ForgotPasswordCommand = new Command(OnForgotPassword);
            SwitchAppearanceOfPassword = new Command(OnSwitchAppearanceOfPassword);
            // SelectAccountCommand = new Command(SelectAccountType);
        }

        private async void SelectAccountType()
        {
            await Shell.Current.GoToAsync("//SelectAccountType");
            // await NavigationService.NavigateTo(typeof(SelectAccountTypePage));
        }

        private async void OnLoginWithGoogle()
        {
            // TODO: зробити сторінку для логіну через Google
            await NavigationService.NavigateTo(typeof(MainPage));
        }

        private async void OnLoginWithFacebook()
        {
            // TODO: зробити сторінку для логіну через Facebook
            await NavigationService.NavigateTo(typeof(MainPage));
        }

        private async void OnLoginWithApple()
        {
            // TODO: зробити сторінку для логіну через Apple
            await NavigationService.NavigateTo(typeof(MainPage));
        }

        private async void OnCreateAccount()
        {
            await Shell.Current.GoToAsync("//SignUp");
            // await NavigationService.NavigateTo(typeof(SignUpPage));
        }
        private async void OnForgotPassword()
        {
            await Shell.Current.GoToAsync("//RecoverPassword");
            // await NavigationService.NavigateTo(typeof(RecoverPasswordPage));
        }

        private void OnSwitchAppearanceOfPassword()
        {
            IsPasswordHidden = !IsPasswordHidden;
        }
    }
}
