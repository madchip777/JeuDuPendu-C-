namespace Hangman.Display
{
    public class Display
    {
        public static void ClearConsole()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3b");
        }

        public static void WelcomeMessage()
        {
            ClearConsole();
            Console.WriteLine(@"
             _____               _       
            |  __ \             | |      
            | |__) |__ _ __   __| |_   _ 
            |  ___/ _ \ '_ \ / _` | | | |
            | |  |  __/ | | | (_| | |_| |
            |_|   \___|_| |_|\__,_|\__,_|
                              ");
        }

    }
}