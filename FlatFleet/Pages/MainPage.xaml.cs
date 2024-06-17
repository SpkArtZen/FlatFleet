using FlatFleet.ViewModels;

namespace FlatFleet
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
        
    }

}
