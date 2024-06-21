using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class RecoverPasswordPageViewModel : ViewModelBase
    {
        
        public ICommand CheckEmailCommand { get; }
        public ICommand CreateAccountCommand { get; }
        
        public RecoverPasswordPageViewModel()
        {
            CheckEmailCommand = new Command(CheckEmail);
            CreateAccountCommand = new Command(CreateAnAccount);
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
                case "//EnterNewPassword":
                    await Shell.Current.GoToAsync("//VerifyEmail");
                    break;
                case "//SelectAccountType":
                    await Shell.Current.GoToAsync("//SignIn");
                    break;
                case "//SelectManagementCompany":
                case "//SelectDoubt":
                case "//SelectTenantOfHouse":
                case "//SelectHouseCommittee":
                case "//UploadFiles":
                    await Shell.Current.GoToAsync("//SelectAccountType");
                    break;
            }
        }
        private async void CheckEmail()
        {
            await Shell.Current.GoToAsync("//VerifyEmail");
            // await NavigationService.NavigateTo(typeof(VerifyEmailPage));
        }
        
        private async void CreateAnAccount()
        {
            await Shell.Current.GoToAsync("//SignUp");
            // await NavigationService.NavigateTo(typeof(SignUpPage));
        }
    }
}
