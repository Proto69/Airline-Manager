namespace Airline_Manager.Views
{
    public static class DatabaseMessageView
    {
        public static void DatabaseSuccess(string feedback)
        {
            // Sets the color of the console to green
            ConsoleColor.Green();

            // Gives feedback
            Console.WriteLine(feedback);

            // Resets the color of the console
            Console.ResetColor();
        }

    }
}
