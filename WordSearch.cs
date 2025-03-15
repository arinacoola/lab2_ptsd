using System.Text.RegularExpressions;

namespace Lab2

{
    public class WordSearch
    {
        public static int Main()
        {
            Console.WriteLine("Enter text: ");
            string input = Console.ReadLine();
    
            if (!IsInputValid(input))
            {
                Console.WriteLine("Input Invalid");
                return 1;
            }
    
            string text = ExtractText(input);
            string word = ExtractWord(input);
    
            int count = CountWordOccurrences(text, word);
    
            Console.WriteLine(count);
            return 0;
        }
    
        public static bool IsInputValid(string input)
        {
            string pattern = @"^-text\s+"".+""\s+-word\s+"".+""$";
            return Regex.IsMatch(input, pattern);
        }
    
        public static string ExtractText(string input)
        {
            Match match = Regex.Match(input, @"-text\s+""(.+?)""");
            return match.Groups[1].Value;
        }
    
        public static string ExtractWord(string input)
        {
            Match match = Regex.Match(input, @"-word\s+""(.+?)""");
            return match.Groups[1].Value;
        }
    
        public static int CountWordOccurrences(string text, string word)
        {
            string pattern = @"\b" + Regex.Escape(word) + @"\b";
            MatchCollection matches = Regex.Matches(text, pattern);
            return matches.Count;
        }
    }
}



