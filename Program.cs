namespace Airline_Manager
{
    internal class Program
    {
        static void Main()
        {
            // Check if this is the first time the game is running
            if (GameSaver.CheckGame())
                ProfileSetup.NewSetup();
        }
    }
}