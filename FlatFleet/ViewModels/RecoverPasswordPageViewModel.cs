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
