using AirRest.Domain.Models.Locations;
using System;

namespace Domain.Transport.Services
{
    public interface IDistanceCalculator
    {
        double CalculateDistanceBetweenEarthLocations(Location first, Location second);
    }

    public class DistanceCalculator : IDistanceCalculator
    {
        public const double EarthRadius = 6371e3;

        /// https://www.movable-type.co.uk/scripts/latlong.html
        public double CalculateDistanceBetweenEarthLocations(Location first, Location second)
        {
            var phi_1 = first.Lattitude * Math.PI / 180;
            var phi_2 = second.Lattitude * Math.PI / 180;

            var deltaPhi = (first.Lattitude - second.Lattitude) * Math.PI / 180;
            var deltaAlpha = (first.Longitue - second.Longitue) * Math.PI / 180;

            var a = Math.Sin(deltaPhi / 2) * Math.Sin(deltaPhi) +
                    Math.Cos(phi_1) * Math.Cos(phi_2) *
                    Math.Sin(deltaAlpha / 2) * Math.Sin(deltaAlpha / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadius * c;
        }
    }
}
