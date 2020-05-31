using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SortingShakespeare.Sorting;
using Utils = SortingShakespeare.Sorting.Utils;

namespace SortingShakespeare {
    class Program {
        private static void Main(string[] args) {
            var tp = new TextProcessor();
            var stopWatch = new Stopwatch();

            const string filename = "Shakespeare.txt";
            const string regex = @"[a-z]+'?-?[a-z]*";

            // This is to find the text files - Without having a long path string.
            Directory.SetCurrentDirectory(Path.Combine(Environment.CurrentDirectory, @"../../../"));
            var path = $@"{Directory.GetCurrentDirectory()}\Data\{filename}";

            tp.ProcessTextFile(path, regex);
            stopWatch.Start();

            Trie.Sort(tp.ProcessedStrings);

            stopWatch.Stop();
            Console.WriteLine(Utils.isSortedMin(tp.ProcessedStrings));
            Console.WriteLine($"Execution Time: {stopWatch.Elapsed} for {tp.ProcessedStrings.Length} elements.\n");
          
            // Preventing to show the sorted Shakespeare.txt
            if (!filename.Equals("Shakespeare.txt")) {
                foreach (var words in tp.ProcessedStrings) {
                    Console.Write($"{words} ");
                }
            }
        }
    }
}