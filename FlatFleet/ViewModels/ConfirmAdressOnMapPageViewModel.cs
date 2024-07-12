using MvvmHelpers;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;
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
        public ICommand MapClickedCommand { get; }
        public ICommand InitializeLocationCommand { get; }

        public ConfirmAdressOnMapPageViewModel(string apiKey)
        {
            _googlePlacesService = new GooglePlacesService(apiKey);
            AddressSuggestions = new ObservableCollection<string>();
            GetPlacePredictionsCommand = new Command(async () => await GetPlacePredictions());
            PinCommand = new Command(async () => await PinLocation());
            MapClickedCommand = new Command<Location>(async (location) => await OnMapClicked(location));
            InitializeLocationCommand = new Command(async () => await InitializeLocation());
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
                var locations = await Geocoding.GetLocationsAsync(Address);
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

        private async Task OnMapClicked(Location location)
        {
            // Reverse geocode the location to get the address
            var placemarks = await Geocoding.GetPlacemarksAsync(location);
            var placemark = placemarks?.FirstOrDefault();

            if (placemark != null)
            {
                var addressParts = new[]
                {   placemark.CountryName,
                    placemark.AdminArea,
                    placemark.Locality,
                    placemark.Thoroughfare,
                    placemark.SubThoroughfare
                };
                var address = string.Join(", ", addressParts.Where(part => !string.IsNullOrWhiteSpace(part)));
                Address = address;

                var pin = new Pin
                {
                    Label = address,
                    Address = address,
                    Type = PinType.Place,
                    Location = location
                };

                Map.Pins.Clear(); // Clear existing pins
                Map.Pins.Add(pin);
                Map.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Location, Distance.FromMiles(1)));
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Помилка", "Не вдалося знайти адресу для цієї точки.", "OK");
            }
        }
        private async Task InitializeLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }

                if (location != null)
                {
                    await OnMapClicked(new Location(location.Latitude, location.Longitude));
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Помилка", "Не вдалося отримати поточне місцезнаходження.", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Помилка", $"Виникла помилка при отриманні місцезнаходження: {ex.Message}", "OK");
            }
        }
    }
}
