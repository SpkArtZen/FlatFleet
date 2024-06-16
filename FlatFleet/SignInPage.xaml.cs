using FlatFleet.ViewModels;

namespace FlatFleet
{
    public partial class SingInPage : ContentPage
    {
        public SingInPage()
        {
            InitializeComponent();
            BindingContext = new SignInViewModel();
        }
    }
}

