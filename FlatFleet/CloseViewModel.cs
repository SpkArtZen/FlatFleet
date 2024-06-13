using Navigation;
using System.Windows.Input;

namespace FlatFleet
{
    public class CloseViewModel : BindableObject
    {
        public ICommand OnCloseDocument { get; }
        public CloseViewModel()
        {
            OnCloseDocument = new Command(CloseToSignUp);

        }
        private async void CloseToSignUp()
        {
            await NavigationService.NavigateTo(typeof(CreateAnAccountPage));
        }
    }
}
