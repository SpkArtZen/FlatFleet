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
        }
        private async void CheckPasswords()
        {
            await NavigationService.NavigateTo(typeof(NewPasswordAcceptedPage));
        }
    }
}
