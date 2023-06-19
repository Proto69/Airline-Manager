namespace Airline_Manager.Models
{
    public static class GlobalVariables
    {
        public static List<Aircraft> AircraftsTxtFile = AircraftDataCollector.GetAllAircrafts();
        public static List<Aircraft> OwnedAircrafts = AircraftData.GetAll();
        public static User User = UserData.GetUser();
        public static List<Route> Routes = RouteData.GetAll();
    }
}
