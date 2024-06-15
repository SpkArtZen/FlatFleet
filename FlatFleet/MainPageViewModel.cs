using Navigation;
using System.ComponentModel;
using System.Windows.Input;

namespace FlatFleet
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
            await NavigationService.NavigateTo(typeof(GetStarted));
        }

        private async void OnSignIn()
        {
            await NavigationService.NavigateTo(typeof(SignIn));
        }
    }
}
