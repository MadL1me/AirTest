using AirRest.Domain.Models.Locations;

namespace AirRest.Domain.Models
{
    public class Airport : TransportNode
    {
        public string Country { get; set; }

        public string CityIata { get; set; }

        public string Iata { get; set; }

        public string City { get; set; }

        public string TimezoneRegionName { get; set; }

        public string CountryIata { get; set; }

        public int Rating { get; set; }

        public string Name { get; set; }

        public int Hubs { get; set; }

        public override LocationType LocationType => LocationType.Airport;
    }
}
