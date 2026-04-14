namespace JeuDuPendu_C_.lib;

public class PlayerInputs
{
    public static string AskStringInput()
    {
        var mot = Console.ReadLine();
        if (mot == null){return "";}
        return mot;
    }

    public static char? AskCharInput()
    {
        return Console.ReadKey().KeyChar;
    }

    public static int? AskNumberInput()
    {
        return Convert.ToInt32(Console.ReadLine());
    }
    
    public static int? AskDigitInput()
    {
        return Convert.ToInt32(Console.ReadKey().KeyChar);
    }
}