namespace Airline_Manager.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Km { get; set; }
        public int DailyDemand { get; set; }
        public int Fuel { get; set; }

        public Route(int id, string from, string to, double n1, double e1, double n2, double e2, int dailyDemand)
        {
            this.Id = id;
            this.From = from;
            this.To = to;
            this.Km = CalculateDistance(n1, e1, n2, e2);
            this.DailyDemand = dailyDemand;
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
