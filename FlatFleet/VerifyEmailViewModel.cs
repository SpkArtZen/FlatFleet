using Navigation;
using System.Windows.Input;

namespace FlatFleet
{
    public class VerifyEmailViewModel : BindableObject
    {
        public ICommand VerifyCodeOnEmail { get; }
        public VerifyEmailViewModel() 
        {
            VerifyCodeOnEmail = new Command(CheckEmailCode);
        }
        private async void CheckEmailCode()
        {
            await NavigationService.NavigateTo(typeof(EntryNewPasswordPage));
        }
    }
}
