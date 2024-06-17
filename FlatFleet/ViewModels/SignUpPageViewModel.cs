using System.Windows.Input;
using Firebase.Auth;
using FlatFleet.Features.SignUp;
using FlatFleet.ViewModels;
using FlatFleet.Features.Navigation;

namespace FlatFleet
{
    public class SignUpPageViewModel : ViewModelBase
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

        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
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

        private string _phoneNumber;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public ICommand SignUpCommand { get; }
        public ICommand OnTermsOfServiceCommand { get; }
        public ICommand OnPrivacePolicyCommand { get; }
        public ICommand OnSignInCommand { get; }

        public SignUpPageViewModel(FirebaseAuthClient authClient)
        {
            SignUpCommand = new SignUpCommand(this, authClient);
            OnTermsOfServiceCommand = new Command(OnTermsOfService);
            OnPrivacePolicyCommand = new Command(OnPrivacePolicy);
            OnSignInCommand = new Command(OnSingIn);
        }
        private async void OnTermsOfService()
        {
            await NavigationService.NavigateTo(typeof(TermsOfServicePage));
        }

        private async void OnPrivacePolicy()
        {
            await NavigationService.NavigateTo(typeof(PrivacyPolicyPage));
        }

        private async void OnSingIn()
        {
            await NavigationService.NavigateTo(typeof(SignInPage));
        }
    }
}
