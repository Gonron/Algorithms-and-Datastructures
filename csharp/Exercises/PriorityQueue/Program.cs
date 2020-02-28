using System;

namespace PriorityQueue {
    
    class Program {
        
        static void Main(string[] args) {
           
            var stringQueue = new  LinkedPriorityQueue<string>();
            var doubleQueue =  new LinkedPriorityQueue<double>();
            var doubleArray = new[] {
                644.08, 4121.85, 2678.40, 4409.74, 837.42, 
                3229.27, 4732.35, 4381.21, 66.10, 4747.08, 
                2156.86,  1025.70, 2520.97, 708.05, 3532.36, 4050.20
            };
            var stringArray = new[] {
                "Turing", "vonNeumann", "Dijkstra", "vonNeumann", "Dijkstra", 
                "Hoare", "vonNeumann", "Hoare", "Turing", "Thompson", 
                "Turing", "Hoare", "vonNeumann", "Dikjstra", "Turing", "Hoare"
            };

            foreach (var str in stringArray) {
                stringQueue.Enqueue(str);
            }
            
            Console.Write("Char queue contents: ");
            while (!stringQueue.IsEmpty()) {
                Console.Write(stringQueue.Dequeue() + " ");
            }
            
            Console.WriteLine();
            
            foreach (var d in doubleArray) {
                doubleQueue.Enqueue(d);
            }
            
            Console.Write("Double queue contents: ");
            while (!doubleQueue.IsEmpty()) {
                Console.Write(doubleQueue.Dequeue() + "  ");
            }
            
            
        }
    }
}
