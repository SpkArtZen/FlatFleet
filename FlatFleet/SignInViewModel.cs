using Microsoft.Maui.Controls;
using System.Windows.Input;
using Navigation;

namespace FlatFleet
{
    public class SignInViewModel : BindableObject
    {
        public ICommand LoginWithGoogleCommand { get; }

        public SignInViewModel()
        {
            LoginWithGoogleCommand = new Command(OnLoginWithGoogle);
        }

        private async void OnLoginWithGoogle()
        {
            // Ваш код для обробки входу через Google
            await NavigationService.Navigate(typeof(MainPage));
        }
    }
}
