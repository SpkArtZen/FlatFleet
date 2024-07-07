using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public class GooglePlacesService
{
    private readonly string apiKey;
    private readonly HttpClient httpClient;

    public GooglePlacesService(string apiKey)
    {
        this.apiKey = apiKey;
        httpClient = new HttpClient();
    }

    public async Task<List<string>> GetPlacePredictionsAsync(string input)
    {
        string url = $"https://maps.googleapis.com/maps/api/place/autocomplete/json?input={input}&key={apiKey}";

        HttpResponseMessage response = await httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            var predictions = JObject.Parse(json)["predictions"];
            List<string> results = new List<string>();

            foreach (var prediction in predictions)
            {
                results.Add(prediction["description"].ToString());
            }

            return results;
        }
        return null;
    }
}
