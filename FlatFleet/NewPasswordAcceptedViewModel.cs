using Navigation;
using System.Windows.Input;

namespace FlatFleet
{
    public class NewPasswordAcceptedViewModel : BindableObject
    {
        public ICommand OnSignInCommand { get; }
        public NewPasswordAcceptedViewModel()
        {
            OnSignInCommand = new Command(OnSignIn);
        }
        private async void OnSignIn()
        {
            await NavigationService.NavigateTo(typeof(SignIn));
        }
    }
}
