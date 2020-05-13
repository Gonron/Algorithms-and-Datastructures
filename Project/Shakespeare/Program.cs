using System;
using Shakespeare.Sorting;

namespace Shakespeare {
    class Program {
        static void Main(string[] args) {
            var tp = new TextProcessor();
            const string path = @"C:\Users\lunds\Desktop\CPHBusiness\soft\Algorithms-and-Datastructures\csharp\Project\Shakespeare\data\BigShakespeare.txt";
            const string regex = @"[a-zA-Z]+'?[a-zA-Z]*";
            
            /*
             * There's either a problem somewhere in my TextProcessor, where it sorts double a's
             * ex. Aaron to the back of the array.
             */
            
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            
            tp.ProcessTextFile(path, regex);
            Heap.Sort(tp.ProcessedStrings);
            
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            
            
            foreach (var words in tp.ProcessedStrings) {
                Console.Write($"{words} ");
            }
            
        }
    }
}