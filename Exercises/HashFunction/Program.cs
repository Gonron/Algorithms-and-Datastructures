using System;
using System.Linq;

namespace HashFunction {
    class Program {
        public static void test(string[] words, Func<string, int> hash) {
            //int[] hashes = new int[32];
            foreach (var word in words) {
                //int h = hash(word);
                //hashes[h]++;

                Console.Write(hash(word) + " ");
            }

            //histogram.print(hashes);
        }

        static void Main(string[] args) {
            //var path = "C:\\Users\\lunds\\Desktop\\CPHBusiness\\soft\\Algorithms-and-Datastructures\\csharp\\Exercises\\HashFunction\\data\\text.txt";
            //var regex = @"[a-zA-Z]+'?[a-zA-Z]*";

            //var tp = new TextProcessor();
            //tp.ProcessTextFile(path, regex);

            //test(tp.ProcessedStrings,  k => k.Length);
            var words = new string[] {"to", "be", "or", "not", "to", "be"};
            Console.WriteLine("\nFirst Char: ");
            test(words, s => s[0] % 32);
            Console.WriteLine("\nLast Char: ");
            test(words, s => s[^1] % 32);
            Console.WriteLine("\nSum: ");
            test(words, s => s.Sum(w => w) % 32);
            Console.WriteLine("\nHashCode: ");
            test(words, s => s.GetHashCode() % 32);
        }
    }
}