using System.Windows.Input;
using Microsoft.Maui.Controls;
using Navigation;

namespace FlatFleet
{
    public class MainPageViewModel : BindableObject
    {
        public ICommand SignInCommand { get; }
        public ICommand GetStartedCommand { get; }
        public MainPageViewModel()
        {
            SignInCommand = new Command(OnSignInBtn_Click);
            GetStartedCommand = new Command(OnGetStartedBtn_Click);
        }
        public static async void OnSignInBtn_Click()
        {
            await NavigationService.NavigateTo(typeof(SignIn));
        }
        public static async void OnGetStartedBtn_Click()
        {
            await NavigationService.NavigateTo(typeof(GetStarted));
        }
    }
}
