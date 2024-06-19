using System.Windows.Input;
using Firebase.Auth;
using FlatFleet.Features.SignUp;
using FlatFleet.ViewModels;
using FlatFleet.Features.Navigation;
using FlatFleet.Models.Users;
using Google.Cloud.Firestore.V1;
using Google.Cloud.Firestore;

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

        public ICommand SignUpCommand { get; }
        public ICommand OnTermsOfServiceCommand { get; }
        public ICommand OnPrivacePolicyCommand { get; }
        public ICommand OnSignInCommand { get; }
        public ICommand SwitchAppearanceOfPassword { get; }

        public SignUpPageViewModel(FirebaseAuthClient authClient, FirestoreDb db, CurrentUserStore userStore)
        {
            SignUpCommand = new SignUpCommand(this, authClient, db, userStore);
            OnTermsOfServiceCommand = new Command(OnTermsOfService);
            OnPrivacePolicyCommand = new Command(OnPrivacePolicy);
            OnSignInCommand = new Command(OnSingIn);
            SwitchAppearanceOfPassword = new Command(OnSwitchAppearanceOfPassword);
        }
        private async void OnTermsOfService()
        {
            await Shell.Current.GoToAsync("//TermsOfService");
            // await NavigationService.NavigateTo(typeof(TermsOfServicePage));
        }

        private async void OnPrivacePolicy()
        {
            await Shell.Current.GoToAsync("//PrivacyPolicy");
            // await NavigationService.NavigateTo(typeof(PrivacyPolicyPage));
        }

        private async void OnSingIn()
        {
            await Shell.Current.GoToAsync("//SignIn");
            //await NavigationService.NavigateTo(typeof(SignInPage));
        }

        private void OnSwitchAppearanceOfPassword()
        {
            IsPasswordHidden = !IsPasswordHidden;
        }
    }
}
