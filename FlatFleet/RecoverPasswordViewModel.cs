using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Navigation;

namespace FlatFleet
{
    public class RecoverPasswordViewModel : BindableObject
    {
        public ICommand CheckEmailCommand { get; }
        public ICommand CreateAccountCommand { get; }
        public RecoverPasswordViewModel()
        {
            CheckEmailCommand = new Command(CheckEmail);
            CreateAccountCommand = new Command(CreateAnAccount);
        }
        private async void CheckEmail()
        {
            await NavigationService.NavigateTo(typeof(VerifyEmailPage));
        }
        private async void CreateAnAccount()
        {
            await NavigationService.NavigateTo(typeof(CreateAnAccountPage));
        }
    }
}
