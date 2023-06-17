namespace Airline_Manager.Models
{
    public class Route
    {
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Km { get; set; }
        public int DailyDemand { get; set; }

        public Route(string name, Airport airport_to, Airport airport_from)
        {
            this.Name = name;
            this.From = airport_from.City;
            this.To = airport_to.City;
            this.Km = CalculateDistance(airport_to.North, airport_to.East, airport_from.North, airport_from.East);
        }

        public Route(string name, Airport airport_to, Airport airport_from, int km)
        {
            this.Name = name;
            this.From = airport_from.City;
            this.To = airport_to.City;
            this.Km = km;
        }

        public int CalculateFuel(int fuelPerKm)
        {
            return Km * fuelPerKm;
        }

        private int CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double radius = 6371; // Radius of the Earth in kilometers

            // Convert decimal degrees to radians
            double lat1Rad = ToRadians(lat1);
            double lon1Rad = ToRadians(lon1);
            double lat2Rad = ToRadians(lat2);
            double lon2Rad = ToRadians(lon2);

            // Haversine formula
            double dlat = lat2Rad - lat1Rad;
            double dlon = lon2Rad - lon1Rad;
            double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
                       Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                       Math.Sin(dlon / 2) * Math.Sin(dlon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = radius * c;

            return (int)Math.Round(distance);
        }

        private double ToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }
    }
}
