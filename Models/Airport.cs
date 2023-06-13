namespace Airline_Manager.Models
{
    // Model for an airport
    public class Airport
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Code { get; set; }
        public double North { get; set; }
        public double East { get; set; }

        public Airport(string city, string country, string code, double north, double east)
        {
            this.City = city;
            this.Country = country;
            this.Code = code;
            this.North = north;
            this.East = east;
        }
    }
}
