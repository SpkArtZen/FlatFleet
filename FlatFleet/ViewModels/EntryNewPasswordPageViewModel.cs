using FlatFleet.Features.Navigation;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class EntryNewPasswordPageViewModel : BindableObject
    {
        public ICommand CheckPasswordsSuitability { get; }
        public EntryNewPasswordPageViewModel()
        {
            CheckPasswordsSuitability = new Command(CheckPasswords);
            GoToPreviousPageCommand = new Command(BackToPrevPage);
        }
        public ICommand GoToPreviousPageCommand { get; }
        private async void BackToPrevPage()
        {
            string currentRoute = Shell.Current.CurrentState.Location.ToString();

            switch (currentRoute)
            {
                case "//RecoverPassword":
                    await Shell.Current.GoToAsync("//SignIn");
                    break;
                case "//SignIn":
                    await Shell.Current.GoToAsync("//GetStarted");
                    break;
                case "//VerifyEmail":
                    await Shell.Current.GoToAsync("//RecoverPassword");
                    break;
                case "//EntryNewPasswordPage":
                    await Shell.Current.GoToAsync("//VerifyEmail");
                    break;
                case "//SelectAccountTypePage":
                    await Shell.Current.GoToAsync("//SignIn");
                    break;
                case "//ManagementCompanyPage":
                case "//DoubtPage":
                case "//TenantOfHousePage":
                case "//HouseCommitteePage":
                    await Shell.Current.GoToAsync("//GetStarted");
                    break;
            }
        }
        private async void CheckPasswords()
        {
            await Shell.Current.GoToAsync("//NewPasswordAccepted");
            // await NavigationService.NavigateTo(typeof(NewPasswordAcceptedPage));
        }
    }
}
