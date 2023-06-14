namespace Airline_Manager
{
    // Class for controlling the console font color
    public static class ConsoleColor
    {
        public static void Green()
        {
            Console.ForegroundColor = System.ConsoleColor.Green;
        }

        public static void Red()
        {
            Console.ForegroundColor = System.ConsoleColor.Red;
        }

        public static void Yellow()
        {
            Console.ForegroundColor = System.ConsoleColor.Yellow;
        }

        public static void Blue()
        {
            Console.ForegroundColor = System.ConsoleColor.Blue;
        }

        public static void Reset()
        {
            Console.ResetColor();
        }
    }
}
