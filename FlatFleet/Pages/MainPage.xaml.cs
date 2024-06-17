using FlatFleet.ViewModels;

namespace FlatFleet
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
        
    }
}
