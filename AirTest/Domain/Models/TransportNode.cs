using AirRest.Domain.Models.Locations;

namespace AirRest.Domain.Models
{
    public abstract class TransportNode
    {
        public abstract LocationType LocationType { get; }

        public Location Location { get; set; }
    }
}
