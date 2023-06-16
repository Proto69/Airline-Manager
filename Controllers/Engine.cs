namespace Airline_Manager.Controllers
{
    public static class Engine
    {
        public static void Run()
        {
            // Check if this is the first time the game is running
            if (GameSaver.CheckGame())
                ProfileSetup.NewSetup();

            // Displays a table with all currently owned aircrafts

        }
    }
}
