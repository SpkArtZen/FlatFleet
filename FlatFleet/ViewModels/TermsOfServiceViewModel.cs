using Navigation;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class TermsOfServiceViewModel : BindableObject
    {
        public ICommand OnSignUpCommand { get; }
        public TermsOfServiceViewModel()
        {
            OnSignUpCommand = new Command(OnSignUp);
        }
        private async void OnSignUp()
        {
            await NavigationService.NavigateTo(typeof(CreateAnAccountPage));
        }
    }
}
