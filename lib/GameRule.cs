using System.Text;

namespace Hangman.GameRule
{
    public class GameRule
    {
        private static Random rng = new Random();

        public static string[] LoadWords()
        {
            string[] words = File.ReadAllLines("words.txt");
            return words;
        }

        public static string RandomWord()
        {
            string[] words = LoadWords();
            return words[rng.Next(0, words.Length)];
        }

        public static string HideWord(string word, int percentage)
        {
            int lettersToReveal = (int) Math.Round((double) word.Length * percentage / 100);
            List<int> indexes = Enumerable.Range(0, word.Length).ToList();
            indexes = indexes.Shuffle().ToList();

            List<int> toReveal = indexes.Take(lettersToReveal).ToList();
            string result = "";

            for (int i = 0; i < word.Length; i++)
            {
                if (toReveal.Contains(i))
                {
                    result += word[i];
                    result = ReplaceAllOccurence(word, result, word[i].ToString());
                }
                else
                {
                    result += "_";
                }
            }
            return result;
        }

        public static string PlayerGuess(string word, string input, string guess)
        {
            if (input.Length == 0)
            {
                return "";
            }
            
            if (input.Length > 1 && input.ToLower().Equals(word))
            {
                return word;
            }
            else
            {
                if (word.Contains(input))
                {
                    return ReplaceAllOccurence(word, guess, input);
                }
                return guess;
            }
        }

    public static string ReplaceAllOccurence(string word, string guess, string input)
        {
            char letterInput = input[0];
            StringBuilder result = new StringBuilder(guess);
            for (int i = 0; i < guess.Length; i++)
            {
                if (word[i] == letterInput && result[i] == '_')
                {
                    result[i] = letterInput;
                }
            }
            return result.ToString();
        }

    public static bool HasWon(string word, string guess)
        {
            return word.Equals(guess);
        }

    }
}