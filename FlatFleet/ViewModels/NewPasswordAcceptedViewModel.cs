using Navigation;
using System.Windows.Input;

namespace FlatFleet.ViewModels
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
