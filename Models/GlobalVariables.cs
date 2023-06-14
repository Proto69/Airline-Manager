namespace Airline_Manager.Models
{
    public static class GlobalVariables
    {
        public static List<Aircraft> Aircrafts = AircraftDataCollector.GetAllAircrafts();
    }
}
