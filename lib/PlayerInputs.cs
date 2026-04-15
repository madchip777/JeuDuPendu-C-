namespace Hangman.PlayerInputs;

public class PlayerInputs
{
    public static string AskStringInput()
    {
        var mot = Console.ReadLine();
        if (mot == null)
        {
            return "";
        }
        return mot;
    }

    public static char? AskCharInput()
    {
        return Console.ReadKey().KeyChar;
    }

    public static int AskNumberInput()
    {
        var input = Console.ReadLine();
        if (input == null) return 0;
        return Convert.ToInt32(input);
    }
    
    public static int? AskDigitInput()
    {
        return Convert.ToInt32(Console.ReadKey().KeyChar);
    }
}