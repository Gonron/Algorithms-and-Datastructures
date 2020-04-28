using System;
using System.Text.RegularExpressions;

namespace Regex101 {
    class Program {
        static void Main(string[] args) {
            string pattern = @"\ba\w*\b";
            string input = "An extraordinary day dawns with each new day.";
            Match m = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
            if (m.Success)
                Console.WriteLine("Found '{0}' at position {1}.", m.Value, m.Index);
        }
    }
}