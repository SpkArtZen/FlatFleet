using FlatFleet.Features.Navigation;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        public ICommand OnSignInCommand { get; }
        public ICommand ToGetStartedCommand { get; }

        public MainPageViewModel()
        {
            ToGetStartedCommand = new Command(OnGetStartedBtn_Click);
            OnSignInCommand = new Command(OnSignIn);
        }
        public static async void OnGetStartedBtn_Click()
        {
            await Shell.Current.GoToAsync("//GetStarted");
        }

        private async void OnSignIn()
        {
            await Shell.Current.GoToAsync("//SignIn");
        }
    }
}
