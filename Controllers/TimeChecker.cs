namespace Airline_Manager.Controllers
{
    public static class TimeChecker
    {
        public static void CheckTime()
        {
            List<Aircraft> list = AircraftData.GetAll();
            foreach (Aircraft aircraft in list)
            {
                if (aircraft.Landing <= DateTime.Now)
                {
                    aircraft.Land();
                }
            }
        }

        public static string TimeLeft(Aircraft aircraft)
        {
            DateTime time = DateTime.Now;
            return (time - aircraft.Landing).ToString("HH:mm:ss");
        }
    }
}
