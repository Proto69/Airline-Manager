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
        public Route Route { get; set; }
        public bool Airborne { get; set; }
        public int Wear { get; set; }
        public DateTime Landing { get; set; }

        public Aircraft(string man, string model, int pax, int fuel, int speed, int range, int cost, int wear)
        {
            this.Manifacturer = man;
            this.Model = model;
            this.Passangers = pax;
            this.FuelConsumption = fuel;
            this.MaxSpeed = speed;
            this.Range = range;
            this.Cost = cost;
            this.Airborne = false;
            this.Wear = wear;
            this.Route = null;
        }

        public void SetRoute(Route route)
        {
            this.Route = route;
        }

        public void Land()
        {
            Airborne = false;
            AircraftData.Land(this);
        }

        public void Depart()
        {
            if (Wear >= 80)
                throw new InvalidOperationException("You should fix this aircraft before departure!");
            if (Route.CalculateFuel(FuelConsumption) >= GlobalVariables.User.Fuel)
                throw new InvalidOperationException("You don't have enough fuel for this route!");
            if (Airborne)
                throw new InvalidOperationException("This plane is already airborne!");
            Wear += (int)Math.Round(Route.Km * 0.002);
            GlobalVariables.User.Fuel -= Route.CalculateFuel(FuelConsumption);
            Airborne = true;
            Landing = CalculateTime();
            AircraftData.Depart(this);
        }

        private DateTime CalculateTime()
        {
            DateTime now = DateTime.Now;
            int m = Route.Km * 1000;
            int speed = MaxSpeed * 10 / 36;
            int time = m / speed;
            now.AddSeconds(time);
            return now;
        }

        public override string ToString()
        {
            return $"Manifacturer: {this.Manifacturer} Model: {this.Model} \n" +
                $"Passengers: {this.Passangers} Cruise Speed: {this.MaxSpeed} Fuel per km: {this.FuelConsumption} \n" +
                $"Range: {this.Range} Cost: {this.Cost} \n";
        }
    }
}
