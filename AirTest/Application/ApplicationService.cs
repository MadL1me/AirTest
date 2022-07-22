using AirRest.Data;
using Domain.Transport.Services;
using System.Threading.Tasks;

namespace AirRest.Application
{
    public interface IApplicationService
    {
        Task<double> GetDistanceBetweenTwoAirports(string firstAirportIata, string secondAirportIata);
    }

    public class ApplicationService : IApplicationService
    {
        private readonly IAirportInfoRepository _airportInfoRepository;
        private readonly IDistanceCalculator _distanceCalculator;

        public ApplicationService(IAirportInfoRepository airportInfoRepository, IDistanceCalculator distanceCalculator)
        {
            _airportInfoRepository = airportInfoRepository;
            _distanceCalculator = distanceCalculator;
        }

        public async Task<double> GetDistanceBetweenTwoAirports(string firstAirportIata, string secondAirportIata)
        {
            var firstAirport = await _airportInfoRepository.GetAirportByIata(firstAirportIata);
            var secondAirport = await _airportInfoRepository.GetAirportByIata(secondAirportIata);

            return _distanceCalculator.CalculateDistanceBetweenEarthLocations(firstAirport.Location, secondAirport.Location);
        }
    }
}
