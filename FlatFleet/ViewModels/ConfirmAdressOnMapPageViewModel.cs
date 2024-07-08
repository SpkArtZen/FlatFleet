using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls.Maps; 
using System.Collections.Generic;
using Microsoft.Maui.Maps;

namespace FlatFleet.ViewModels
{
    public class ConfirmAdressOnMapPageViewModel : BaseViewModel
    {
        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                if (SetProperty(ref _address, value))
                {
                    GetPlacePredictionsCommand.Execute(null);
                }
            }
        }

        private Microsoft.Maui.Controls.Maps.Map _map;
        public Microsoft.Maui.Controls.Maps.Map Map
        {
            get => _map;
            set => SetProperty(ref _map, value);
        }

        private readonly GooglePlacesService _googlePlacesService;
        public ObservableCollection<string> AddressSuggestions { get; set; }

        public ICommand GetPlacePredictionsCommand { get; }
        public ICommand PinCommand { get; }

        public ConfirmAdressOnMapPageViewModel(string apiKey)
        {
            _googlePlacesService = new GooglePlacesService(apiKey);
            AddressSuggestions = new ObservableCollection<string>();
            GetPlacePredictionsCommand = new Command(async () => await GetPlacePredictions());
            PinCommand = new Command(async () => await PinLocation());
        }

        private async Task GetPlacePredictions()
        {
            if (!string.IsNullOrWhiteSpace(Address))
            {
                var predictions = await _googlePlacesService.GetPlacePredictionsAsync(Address);
                AddressSuggestions.Clear();
                if (predictions != null)
                {
                    foreach (var prediction in predictions)
                    {
                        AddressSuggestions.Add(prediction);
                    }
                }
            }
        }

        private async Task PinLocation()
        {
            if (!string.IsNullOrWhiteSpace(Address))
            {
                var locations = await Microsoft.Maui.Devices.Sensors.Geocoding.GetLocationsAsync(Address);
                var location = locations?.FirstOrDefault();

                if (location != null)
                {
                    var pin = new Pin
                    {
                        Label = Address,
                        Address = Address,
                        Type = PinType.Place,
                        Location = new Location(location.Latitude, location.Longitude)
                    };

                    Map.Pins.Add(pin);
                    Map.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Location, Distance.FromMiles(1)));
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Помилка", "Не вдалося знайти вказану адресу.", "OK");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Помилка", "Будь ласка, введіть адресу.", "OK");
            }
        }
    }
}
