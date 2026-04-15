namespace Hangman.GameLoop
{
    using Hangman.GameRule;
    using Hangman.Display;
    using Hangman.PlayerInputs;

    public class GameLoop
    {
        
        private Boolean inGame;
        private int Lives;
        private String Word;
        private String Guess;
        private List<string> Letters;

        public GameLoop(int toReveal)
        {
            inGame = true;
            Lives = 10;
            Word = GameRule.RandomWord();
            Guess = GameRule.HideWord(Word, toReveal);
            Letters = new List<string>{};
            Start();
        }

    private void Start()
        {
            Display.InGame(Lives, Guess, Letters);
            while (inGame)
            {
                string input = PlayerInputs.AskStringInput();
                string inputCopy = input;
                input = GameRule.PlayerGuess(Word, input, Guess);
                
                if (input.Length != Guess.Length)
                {
                    Lives--;
                }
                else if (Guess != input)
                {
                    Guess = input;
                }
                else
                {
                    if (inputCopy.Length == 1)
                    {
                        Lives--;
                        Letters.Add(inputCopy);
                    }
                    else
                    {
                        Lives -= 2;
                    }
                }
                
                if (GameRule.HasWon(Word, Guess))
                {
                    Display.GameWon();
                    Display.QuitOrRestart(Word);
                    inGame = false;
                    return;
                }

                Display.InGame(Lives, Guess, Letters);

                if (Lives < 1)
                {
                    Display.GameLost();
                    Display.QuitOrRestart(Word);
                    return;
                }
            }
        }

    }
}