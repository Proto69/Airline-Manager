namespace Airline_Manager.Models
{
    // Model for an aircraft
    public class Aircraft
    {
        public string Manifacturer { get; set; }
        public string Model { get; set; }
        public int Passangers { get; set; }
        public int FuelConsumption { get; set; }
        public int MaxSpeed { get; set; }
        public int Range { get; set; }
        public int Cost { get; set; }

        public Aircraft(string man, string model, int pax, int fuel, int speed, int range, int cost)
        {
            this.Manifacturer = man;
            this.Model = model;
            this.Passangers = pax;
            this.FuelConsumption = fuel;
            this.MaxSpeed = speed;
            this.Range = range;
            this.Cost = cost;
        }

        public override string ToString()
        {
            return $"Manifacturer: {this.Manifacturer} Model: {this.Model} \n" +
                $"Passengers: {this.Passangers} Cruise Speed: {this.MaxSpeed} Fuel per km: {this.FuelConsumption} \n" +
                $"Range: {this.Range} Cost: {this.Cost} \n";
        }
    }
}
