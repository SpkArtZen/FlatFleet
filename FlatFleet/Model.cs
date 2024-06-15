using Navigation;
using System.ComponentModel;
using System.Windows.Input;

namespace FlatFleet
{
    public class Model : BindableObject
    {
        private int clickCount = 0;
        private bool isFrame1Visible = true;
        private bool isFrame4Visible = false;
        private Color pointOneColor = Colors.Blue;
        private Color pointFourColor = Colors.LightGray;
        public ICommand LoginWithGoogleCommand { get; }
        public ICommand LoginWithFacebookCommand { get; }
        public ICommand LoginWithAppleCommand { get; }
        public ICommand CreateAccountCommand { get; }
        public ICommand ForgotPasswordCommand { get; }
        public ICommand GetStartedCommand { get; }
        public ICommand OnTermsOfServiceCommand { get; }
        public ICommand OnPrivacePolicyCommand { get; }
        public ICommand OnSignInCommand { get; }
        public ICommand OnCloseDocument { get; }
        public ICommand ToGetStartedCommand { get; }
        public ICommand CheckEmailCommand { get; }
        public ICommand VerifyCodeOnEmail { get; }
        public ICommand CheckPasswordsSuitability { get; }
        public bool IsFrame1Visible
        {
            get => isFrame1Visible;
            set
            {
                if (isFrame1Visible != value)
                {
                    isFrame1Visible = value;
                    OnPropertyChanged(nameof(IsFrame1Visible));
                }
            }
        }

        public bool IsFrame4Visible
        {
            get => isFrame4Visible;
            set
            {
                if (isFrame4Visible != value)
                {
                    isFrame4Visible = value;
                    OnPropertyChanged(nameof(IsFrame4Visible));
                }
            }
        }

        public Color PointOneColor
        {
            get => pointOneColor;
            set
            {
                if (pointOneColor != value)
                {
                    pointOneColor = value;
                    OnPropertyChanged(nameof(PointOneColor));
                }
            }
        }

        public Color PointFourColor
        {
            get => pointFourColor;
            set
            {
                if (pointFourColor != value)
                {
                    pointFourColor = value;
                    OnPropertyChanged(nameof(PointFourColor));
                }
            }
        }

        public Model()
        {
            GetStartedCommand = new Command(async () => await OnGetStarted());
            LoginWithGoogleCommand = new Command(OnLoginWithGoogle);
            LoginWithFacebookCommand = new Command(OnLoginWithFacebook);
            LoginWithAppleCommand = new Command(OnLoginWithApple);
            CreateAccountCommand = new Command(OnCreateAccount);
            ForgotPasswordCommand = new Command(OnForgotPassword);
            OnTermsOfServiceCommand = new Command(OnTermsOfService);
            OnPrivacePolicyCommand = new Command(OnPrivacePolicy);
            OnSignInCommand = new Command(OnSignIn); 
            OnCloseDocument = new Command(CloseToSignUp);
            ToGetStartedCommand = new Command(OnGetStartedBtn_Click);
            CheckEmailCommand = new Command(CheckEmail);
            VerifyCodeOnEmail = new Command(CheckEmailCode);
            CheckPasswordsSuitability = new Command(CheckPasswords);
        }
        private async void CheckPasswords()
        {
            await NavigationService.NavigateTo(typeof(NewPasswordAcceptedPage));
        }
        private async void CheckEmailCode()
        {
            await NavigationService.NavigateTo(typeof(EntryNewPasswordPage));
        }
        private async void CheckEmail()
        {
            await NavigationService.NavigateTo(typeof(VerifyEmailPage));
        }
        public static async void OnGetStartedBtn_Click()
        {
            await NavigationService.NavigateTo(typeof(GetStarted));
        }
        private async void CloseToSignUp()
        {
            await NavigationService.NavigateTo(typeof(CreateAnAccountPage));
        }
        private async Task OnGetStarted()
        {
            clickCount++;

            if (clickCount == 1)
            {
                IsFrame1Visible = false;
                IsFrame4Visible = true;
                // Оновлюємо кольори індикаторів
                PointOneColor = Colors.LightGray;
                PointFourColor = Colors.Blue;
            }
            else if (clickCount == 2)
            {
                // Перехід на сторінку SignIn
                await NavigationService.NavigateTo(typeof(SignIn));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
        private async void OnTermsOfService()
        {
            await NavigationService.NavigateTo(typeof(TermsOfServicePage));
        }

        private async void OnPrivacePolicy()
        {
            await NavigationService.NavigateTo(typeof(PrivacyPolicyPage));
        }

        private async void OnSignIn()
        {
            await NavigationService.NavigateTo(typeof(SignIn));
        }
    }
}
