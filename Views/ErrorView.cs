namespace Airline_Manager.Views
{
    public static class ErrorView
    {
        public static void ThrowError(string message)
        {
            ConsoleColor.Red();
            Console.WriteLine(message);
            ConsoleColor.Reset();
        }
    }
}
