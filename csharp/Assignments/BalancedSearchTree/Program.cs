using System;
using System.ComponentModel.DataAnnotations;

namespace BalancedSearchTree {
    class Program {
        private static void Main(string[] args) {
            var rb = new RedBlackTree<int, int>();
            var values = new[] {100, 30, 20, 90, 80, 70, 40, 60, 50, 10, 100};
            
            for (var i = 0; i < values.Length; i++) {
                rb.Put(values[i], i);
            }
            
            
            var x = rb._root.right.right.left;
            Console.WriteLine("Key: " + x.key);
            Console.WriteLine("Value: " + x.value);
            Console.WriteLine("Color: " + (x.color ? "RED" : "BLACK"));
            


        }
    }
}