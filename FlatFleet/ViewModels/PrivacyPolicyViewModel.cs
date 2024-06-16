using Navigation;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class PrivacyPolicyViewModel : BindableObject
    {
        public ICommand OnSignInCommand { get; }
        public PrivacyPolicyViewModel()
        {
            OnSignInCommand = new Command(OnSignIn);
        }
        private async void OnSignIn()
        {
            await NavigationService.NavigateTo(typeof(CreateAnAccountPage));
        }
    }
}
