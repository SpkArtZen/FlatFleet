using FlatFleet.Features.Navigation;
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
            await Shell.Current.GoToAsync("SignUp");
            // await NavigationService.NavigateTo(typeof(SignUpPage));
        }
    }
}
