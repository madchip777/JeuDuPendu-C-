namespace Hangman.GameLoop
{
    using Hangman.GameRule;
    public class GameLoop
    {
        
        private Boolean inGame;
        private int Lives;
        private String Word;
        private String Guess;
        private string[] Letters;

        public GameLoop()
        {
            inGame = true;
            Lives = 3;
            Word = GameRule.RandomWord();
            Guess = GameRule.HideWord(Word, 50);
            Letters = new string[]{};
            Console.WriteLine(Guess + "    " + Word);
            Start();
        }

    private void Start()
        {
            while (inGame)
            {
                return;
            }
        }

    }
}