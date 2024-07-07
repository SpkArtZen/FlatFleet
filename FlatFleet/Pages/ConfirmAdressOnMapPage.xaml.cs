using FlatFleet.ViewModels;

namespace FlatFleet.Pages
{
    public partial class ConfirmAdressOnMapPage : ContentPage
    {
        public ConfirmAdressOnMapPage()
        {
            InitializeComponent();
            var apiKey = "AIzaSyBLqh84pIo2dePo3xx2eAfAbn8yrbYQtDw"; 
            var viewModel = new ConfirmAdressOnMapPageViewModel(apiKey);
            BindingContext = viewModel;
            viewModel.Map = Map;
        }
    }
}
