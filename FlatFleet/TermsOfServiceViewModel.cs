using Navigation;
using System.Windows.Input;

namespace FlatFleet
{
    public class TermsOfServiceViewModel : BindableObject
    {
        public ICommand OnSignInCommand { get; }
        public TermsOfServiceViewModel() 
        {
            OnSignInCommand = new Command(OnSignIn);
        }
        private async void OnSignIn()
        {
            await NavigationService.NavigateTo(typeof(SignIn));
        }
    }
}
