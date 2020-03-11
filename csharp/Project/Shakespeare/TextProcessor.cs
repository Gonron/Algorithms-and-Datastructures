using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Shakespeare {
    public class TextProcessor {
        public IComparable[] ProcessedStrings { get; private set; }
        
        private static string ReadText(string path) {
            return File.ReadAllText(path);
        }

        private IComparable[] SanitizeText(string text, string regexPattern) {
            var matches = Regex.Matches(text, regexPattern);
            var matchedStrings = new IComparable[matches.Count];
            for (var i = 0; i < matches.Count; i++) {
                matchedStrings[i] = matches[i].ToString();
            }
            return matchedStrings;
        }

        public void ProcessTextFile(string path, string regexPattern) {
            var text = ReadText(path).ToLower();
            ProcessedStrings = SanitizeText(text, regexPattern);
        }
    }
}