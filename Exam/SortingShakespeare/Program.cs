using System;
using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;
using SortingShakespeare.Sorting;

namespace SortingShakespeare {
    class Program {
        static void Main(string[] args) {
            var tp = new TextProcessor();
            var stopWatch = new Stopwatch();

            const string filename = "TestingFile.txt";
            const string path = @"C:\CPHBusiness\Algorithms-and-Datastructures\Exam\SortingShakespeare\Data\" +
                                filename;
            const string regex = @"[a-z][a-z'-]*[a-z]?|[a-z]";

            tp.ProcessTextFile(path, regex);
            stopWatch.Start();

            Selection.Sort(tp.ProcessedStrings, true);

            stopWatch.Stop();
            Console.WriteLine($"Execution Time: {stopWatch.Elapsed}");

            // Preventing to show the sorted Shakespeare.txt
            if (!filename.Equals("Shakespeare.txt")) {
                foreach (var words in tp.ProcessedStrings) {
                    Console.Write($"{words} ");
                }
            }
        }
    }
}