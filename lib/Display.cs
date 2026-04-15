
namespace Hangman.Display
{
    using Hangman.PlayerInputs;
    using Hangman.GameLoop;
 
    public class Display
    {

        public static void ClearConsole()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3b");
        }

        public static void GameTitle()
        {
            ClearConsole();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"
       _                  _         _____               _       
      | |                | |       |  __ \             | |      
      | | ___ _   _    __| |_   _  | |__) |__ _ __   __| |_   _ 
  _   | |/ _ \ | | |  / _` | | | | |  ___/ _ \ '_ \ / _` | | | |
 | |__| |  __/ |_| | | (_| | |_| | | |  |  __/ | | | (_| | |_| |
  \____/ \___|\__,_|  \__,_|\__,_| |_|   \___|_| |_|\__,_|\__,_|
  " + "\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void InGame(int lives, string playerGuess, List<string> letters)
        {
            ClearConsole();
            DrawHangman(lives);
            Console.WriteLine("Vie restantes: " + lives);
            Console.WriteLine("Mot: " + playerGuess);
            var lettersDisplay = string.Join(", ", letters);
            Console.WriteLine("Lettres essayées: " + lettersDisplay+ "\n");      
        }

        public static void DrawHangman(int lives)
        {
            int startAt = (10 - lives) * 7;
            int endAt = startAt + 7;
            string[] file = File.ReadAllLines("states.txt");
            string[] state = file[startAt..endAt];
            foreach (string line in state)
            {
                Console.WriteLine(line);
            }
        }


        public static void GameLost()
        {
            ClearConsole();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
             _____             _         _ 
            |  __ \           | |       | |
            | |__) |__ _ __ __| |_   _  | |
            |  ___/ _ \ '__/ _` | | | | | |
            | |  |  __/ | | (_| | |_| | |_|
            |_|   \___|_|  \__,_|\__,_| (_)
                                
                                ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void GameWon()
        {
            ClearConsole();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"   
             _____                     __   _ 
            / ____|                   /_/  | |
           | |  __  __ _  __ _ _ __   ___  | |
           | | |_ |/ _` |/ _` | '_ \ / _ \ | |
           | |__| | (_| | (_| | | | |  __/ |_|
            \_____|\__,_|\__, |_| |_|\___| (_)
                          __/ |               
                         |___/                ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void QuitOrRestart(string word)
        {
            Console.WriteLine("Le mot était: " + word);
            Console.WriteLine("""
            [1] Menu principal
            [2] Quitter
            """);
            int input = PlayerInputs.AskNumberInput();
            if (input == 1)
            {
                MainMenu();
            }
            else if (input == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Au revoir !");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    

        public static void MainMenu()
        {
            GameTitle();
            Console.WriteLine("""
            [1] Jouer
            [2] Quitter
            """);

            int input = PlayerInputs.AskNumberInput();
            if (input != 1)
            {
                Console.WriteLine("Au revoir");
                return;
            }
            SelectDifficulty();
            

        }
 
        public static void SelectDifficulty()
        {
            GameTitle();
            Console.Write("\nProportion de lettres révélées (en %): ");
            int input = PlayerInputs.AskNumberInput();
            if (input <= 100 && input >= 0)
            {
                new GameLoop(input);
                return;
            }
            SelectDifficulty();
        }

    }
}