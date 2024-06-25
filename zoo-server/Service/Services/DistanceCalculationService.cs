using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DistanceCalculationService
    {
        private const string GoogleMapsDirectionsApiUrl = "https://maps.googleapis.com/maps/api/directions/json";

        private readonly HttpClient _httpClient;

        public DistanceCalculationService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<(double distance, TimeSpan duration)> CalculateWalkingDistanceAndDuration(double originLat, double originLng, double destinationLat, double destinationLng)
        {
            var requestUrl = $"{GoogleMapsDirectionsApiUrl}?origin={originLat},{originLng}&destination={destinationLat},{destinationLng}&mode=walking&key=#####";

            var response = await _httpClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to retrieve directions from Google Maps API.");
            }

            var content = await response.Content.ReadAsStringAsync();

            // Log the JSON response
            Console.WriteLine(content);

            var jsonObject = JObject.Parse(content);

            // Extract distance in meters
            var distance = jsonObject["routes"][0]["legs"][0]["distance"]["value"].Value<double>();

            // Convert distance from meters to kilometers (or any other desired unit)
            double distanceInKm = distance / 1000;

            // Extract duration in seconds
            var duration = jsonObject["routes"][0]["legs"][0]["duration"]["value"].Value<double>();

            // Convert duration from seconds to TimeSpan
            TimeSpan durationTimeSpan = TimeSpan.FromSeconds(duration);

            return (distanceInKm, durationTimeSpan);
        }
    }
}
