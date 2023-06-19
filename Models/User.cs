namespace Airline_Manager.Models
{
    public class User
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public int Fuel { get; set; }
        public string MainHub { get; set; }
        List<string> Hubs { get; set; }
        List<Route> Routes { get; set; }

        public User(string name, string mainHub)
        {
            this.Name = name;
            this.MainHub = mainHub;
            this.Balance = 0;
            this.Fuel = 0;
        }
        public User()
        {
            
        }
    }
}
