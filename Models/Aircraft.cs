namespace Airline_Manager.Models
{
    // Model for an aircraft
    public class Aircraft
    {
        public string Manifacturer { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int Passangers { get; set; }
        public int FuelConsumption { get; set; }
        public int MaxSpeed { get; set; }
        public int Range { get; set; }
        public int Cost { get; set; }

        public Aircraft(string man, string mod, string type, int pax, int fuel, int speed, int range, int cost)
        {
            this.Manifacturer = man;
            this.Model = mod;
            this.Type = type;
            this.Passangers = pax;
            this.FuelConsumption = fuel;
            this.MaxSpeed = speed;
            this.Range = range;
            this.Cost = cost;
        }
    }
}
