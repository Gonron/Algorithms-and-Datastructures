using System;

namespace ArraySorter {
    class Program {
        static void Main(string[] args) {
            var input = new[] {100, 30, 20, 90, 80, 70, 40, 60, 50, 10};
            var arrSorter = new ArraySorter<int>(input, 20);
            
            Console.Write("Sorting descending: ");
            arrSorter.SortDescending();
            foreach (var item in arrSorter.Queue) {
                Console.Write($"{item.ToString()} ");
            }
            
            Console.Write(("\n\nSorting ascending: "));
            arrSorter.SortAscending();
            foreach (var item in arrSorter.Queue) { 
                Console.Write($"{item.ToString()} ");
            }
            
            Console.Write("\n\nRemoving all elements: ");
            while (arrSorter.HeapSize > 0) {
                Console.Write($"\n Removing: {arrSorter.Dequeue().ToString()} \n New Array: ");
                foreach (var item in arrSorter.Queue)
                {
                    Console.Write(item.ToString() + " ");
                }
            }
            
            arrSorter.Enqueue(120);
            Console.WriteLine("\nInserting 120");
            Console.WriteLine($"Dequeuing {arrSorter.Dequeue().ToString()}");
        }
        
        // AdamSai is my hero
    }
}