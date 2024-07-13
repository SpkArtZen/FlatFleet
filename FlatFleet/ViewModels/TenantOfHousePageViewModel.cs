using MvvmHelpers;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class TenantOfHousePageViewModel : BaseViewModel
    {
        private const string apiKey = "AIzaSyDwgWKRWHcrzXmXXRAma0l0Vj3qfT5Yfdk";

        private string addressInput;
        public string AddressInput
        {
            get => addressInput;
            set
            {
                SetProperty(ref addressInput, value);
                if (value.Length > 2)
                {
                    GetPlacePredictionsAsync(value);
                }
                else
                {
                    Suggestions.Clear();
                    Debug.WriteLine("Suggestions cleared due to short input.");
                }
            }
        }

        public ObservableCollection<string> Suggestions { get; }

        public ICommand GoToMapCommand { get; set; }
        public ICommand GoToQRReaderCommand { get; set; }

        public TenantOfHousePageViewModel()
        {
            Suggestions = new ObservableCollection<string>();
            GoToMapCommand = new Command(GoToMap);
            GoToQRReaderCommand = new Command(GoToQRReader);
        }

        private async void GetPlacePredictionsAsync(string input)
        {
            Debug.WriteLine($"Fetching predictions for: {input}");

            var client = new RestClient("https://maps.googleapis.com/maps/api/place/autocomplete/json");
            var request = new RestRequest();
            request.AddParameter("input", input);
            request.AddParameter("key", apiKey);

            var response = await client.ExecuteGetAsync(request);
            if (response.IsSuccessful)
            {
                var content = response.Content;
                Debug.WriteLine($"Response content: {content}");

                JObject jsonResponse = JObject.Parse(content);
                var predictions = jsonResponse["predictions"];

                Suggestions.Clear();
                foreach (var prediction in predictions)
                {
                    Suggestions.Add(prediction["description"].ToString());
                }
                Debug.WriteLine($"Number of suggestions: {Suggestions.Count}");
            }
            else
            {
                Debug.WriteLine($"Error: {response.ErrorMessage}");
            }
        }

        public async void GoToMap()
        {
            await Shell.Current.GoToAsync("///ConfirmAdressOnMap");
        }

        public async void GoToQRReader()
        {
            await Shell.Current.GoToAsync("///QRScanner");
        }
    }
}
