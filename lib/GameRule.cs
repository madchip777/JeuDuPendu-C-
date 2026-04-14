using System.Reflection;

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
                }
                else
                {
                    result += "_";
                }
            }
            return result;
        }

    }
}