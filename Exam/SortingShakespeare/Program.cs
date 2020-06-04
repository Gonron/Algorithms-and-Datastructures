using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SortingShakespeare.Other;
using SortingShakespeare.Searching;
using SortingShakespeare.Sorting;
using Utils = SortingShakespeare.Sorting.Utils;

namespace SortingShakespeare {
    class Program {
        private static void Main(string[] args) {
            var tp = new TextProcessor();
            var stopWatch = new Stopwatch();

            const string filename = "Shakespeare.txt";
            const string regex = @"[a-z]+'?-?[a-z]*";
            const bool isSearching = false;

            // This is to find the text files - Without having a long path string.
            Directory.SetCurrentDirectory(Path.Combine(Environment.CurrentDirectory, @"../../../"));
            var path = $@"{Directory.GetCurrentDirectory()}\Data\{filename}";

            #region Sorting
            
            tp.ProcessTextFile(path, regex);
            stopWatch.Start();
                
            Trie.Sort(tp.ProcessedStrings);

            stopWatch.Stop();
            Console.WriteLine($"isSorted: {Utils.isSortedMin(tp.ProcessedStrings)}");
            Console.WriteLine($"Execution Time: {stopWatch.Elapsed} for sorting {tp.ProcessedStrings.Length} elements.\n");

            // Preventing showing the sorted Shakespeare.txt
            if (!filename.Equals("Shakespeare.txt")) {
                foreach (var words in tp.ProcessedStrings) {
                    Console.Write($"{words} ");
                }
            }

            #endregion


            #region Searching

            if (isSearching) {
                stopWatch.Reset();
                const string target = "z";
                stopWatch.Start();

                //var search = Binary.Search(tp.ProcessedStrings, target, 0, tp.ProcessedStrings.Length - 1);
                var search = Exponential.Search(tp.ProcessedStrings, target, tp.ProcessedStrings.Length - 1);

                stopWatch.Stop();
                Console.WriteLine($"\n\nTarget: \"{target}\" is located at index: {search}.");
                Console.WriteLine(
                    $"Execution Time: {stopWatch.Elapsed} for searching \"{target}\" in {tp.ProcessedStrings.Length} elements.\n");
            }

            #endregion




        }
    }
}