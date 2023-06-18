namespace Airline_Manager.Controllers
{
    public static class Engine
    {
        public static void Run()
        {
            // Check if this is the first time the game is running
            if (GameSaver.CheckGame())
                ProfileSetup.NewSetup();

            TimeChecker.CheckTime();
            ModelView.DisplayAllAircrafts(GlobalVariables.OwnedAircrafts);

            while (true)
            {
                try
                {
                    TimeChecker.CheckTime();
                    ModelView.SendMessage("Write a command, for help type HELP:");
                    string[] input = Console.ReadLine().Split(" ").ToArray();
                    switch (input[0])
                    {
                        case "":
                            ModelView.DisplayAllAircrafts(GlobalVariables.OwnedAircrafts);
                            break;

                        case "HELP":
                            // List all commands
                            break;
                    }
                }
                catch (Exception e)
                {
                    ErrorView.ThrowError(e.Message);
                }
            }

        }
    }
}
