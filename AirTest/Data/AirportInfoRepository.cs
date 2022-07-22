using AirRest.Domain.Models;
using AirRest.Domain.Models.Locations;
using AirRest.Infrastructure;
using System;
using System.Threading.Tasks;

namespace AirRest.Data
{
    public interface IAirportInfoRepository
    {
        Task<Airport> GetAirportByIata(string iata);
    }

    public class AirportInfoApiRepository : IAirportInfoRepository
    {
        private readonly IAirportInfoHttpClient _client;

        public AirportInfoApiRepository(IAirportInfoHttpClient client)
        {
            _client = client;
        }

        public async Task<Airport> GetAirportByIata(string iata)
        {
            if (IsAirportCodeInvalid(iata))
                throw new ArgumentException($"Argument {nameof(iata)} is not valid: Airport iata code must be 3 characters long!");

            var airportDto = await _client.GetAirportByIata(iata);
            
            // We can use automapper here and assign other properties, but i'm lazy to do this
            var airportResult = new Airport
            {
                Location = new Location() 
                {
                    Longitue = airportDto.Location.Lon,
                    Lattitude = airportDto.Location.Lat
                }
            };

            return airportResult;
        }

        private bool IsAirportCodeInvalid(string iata) => iata.Length != 3;
    }
}
