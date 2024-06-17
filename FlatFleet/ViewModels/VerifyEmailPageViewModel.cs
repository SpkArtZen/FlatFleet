using FlatFleet.Features.Navigation;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class VerifyEmailPageViewModel : BindableObject
    {
        public ICommand VerifyCodeOnEmail { get; }
        public VerifyEmailPageViewModel()
        {
            VerifyCodeOnEmail = new Command(CheckEmailCode);
        }
        private async void CheckEmailCode()
        {
            await Shell.Current.GoToAsync("//EnterNewPassword");
            // await NavigationService.NavigateTo(typeof(EntryNewPasswordPage));
        }
    }
}
