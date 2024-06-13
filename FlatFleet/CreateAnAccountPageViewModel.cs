using Navigation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace FlatFleet
{
    public class CreateAnAccountPageViewModel
    {
        public ICommand OnTermsOfServiceCommand { get; }
        public ICommand OnPrivacePolicyCommand { get; }
        public ICommand OnSignInCommand { get; }
        public CreateAnAccountPageViewModel()
        {
            OnTermsOfServiceCommand = new Command(OnTermsOfService);
            OnPrivacePolicyCommand = new Command(OnPrivacePolicy);
            OnSignInCommand = new Command(OnSignIn);
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

