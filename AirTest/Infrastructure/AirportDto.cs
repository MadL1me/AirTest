using AirRest.Domain.Models.Locations;
using System.Text.Json.Serialization;

namespace AirRest.Infrastructure
{
    public class AirportDto
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("city_iata")]
        public string CityIata { get; set; }

        [JsonPropertyName("iata")]
        public string Iata { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("timezone_region_name")]
        public string TimezoneRegionName { get; set; }

        [JsonPropertyName("country_iata")]
        public string CountryIata { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("hubs")]
        public int Hubs { get; set; }

        [JsonPropertyName("location")]
        public LocationDto Location { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public struct LocationDto
    {
        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("lat")]
        public double Lat { get; set; }
    }
}
