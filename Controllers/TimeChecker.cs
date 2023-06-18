namespace Airline_Manager.Controllers
{
    public static class TimeChecker
    {
        public static void CheckTime()
        {
            List<Aircraft> list = AircraftData.GetAll();
            foreach (Aircraft aircraft in list)
            {
                if (aircraft.Airborne && aircraft.Landing <= DateTime.Now)
                {
                    ModelView.SendMessage(aircraft.Land());
                }
            }
        }

        public static string TimeLeft(Aircraft aircraft)
        {
            DateTime time = DateTime.Now;
            TimeSpan result = aircraft.Landing - time;
            return $"{result.Hours}:{result.Minutes}:{result.Seconds}";
        }
    }
}
