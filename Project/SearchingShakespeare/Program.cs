using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SearchingShakespeare {
    internal static class Program {
        private static void Main(string[] args) {
            var text = TextProcessor.ReadText();
            
            var watch = Stopwatch.StartNew();
            var suffixTree = new SuffixTree(text);
            watch.Stop();
            Console.WriteLine($"Total time for building suffix-tree: {watch.ElapsedMilliseconds} milliseconds");
            // Roughly takes 51.000 milliseconds
            
            watch.Reset();
            
            const string searchStr = "to be, or";
            watch.Start();
            var res = (List<string>) suffixTree.Search(searchStr);
            watch.Stop();
            Console.WriteLine($"Total time for searching for {searchStr}: {watch.ElapsedMilliseconds} milliseconds");
            // Took 1 millisecond
            
            Console.WriteLine("Search results: ");
            foreach (var str in res)
            {
                Console.WriteLine(str);
                Console.WriteLine("------------------------------------------------------------------------");
            }
        }
    }
}

/*
 * Credits to Sebastian for the amazing help he has provided
 */