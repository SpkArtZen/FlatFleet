using FlatFleet.ViewModels;
using Microsoft.Maui.Controls.Maps;

namespace FlatFleet.Pages
{
    public partial class ConfirmAdressOnMapPage : ContentPage
    {
        public ConfirmAdressOnMapPage()
        {
            InitializeComponent();
            var apiKey = @"AIzaSyBLqh84pIo2dePo3xx2eAfAbn8yrbYQtDw"; 
            var viewModel = new ConfirmAdressOnMapPageViewModel(apiKey);
            BindingContext = viewModel;
            viewModel.Map = Map;
            // Call the initialize location command after setting the BindingContext
            viewModel.InitializeLocationCommand.Execute(null);
        }
        private void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            var viewModel = (ConfirmAdressOnMapPageViewModel)BindingContext;
            viewModel.MapClickedCommand.Execute(e.Location);
        }
    }
}
