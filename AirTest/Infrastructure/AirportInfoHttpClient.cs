using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AirRest.Infrastructure
{
    public interface IAirportInfoHttpClient
    {
        Task<AirportDto> GetAirportByIata(string iata);
    }

    public class AirportInfoHttpClient : IAirportInfoHttpClient
    {
        private readonly HttpClient _httpClient;

        public AirportInfoHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AirportDto> GetAirportByIata(string iata)
        {
            var result = await _httpClient.GetAsync($"https://places-dev.cteleport.com/airports/{iata}");
            var json = await result.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<AirportDto>(json);
        }
    }
}
