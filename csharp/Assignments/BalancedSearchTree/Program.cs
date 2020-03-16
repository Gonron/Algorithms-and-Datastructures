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
            
            
            var x = rb._root.left.left.right;
            Console.WriteLine("Key: " + x.key);
            Console.WriteLine("Value: " + x.value);
            Console.WriteLine("Color: " + (x.color ? "RED" : "BLACK"));
            
            /*
             *         Color ain't correct
             *                    70B
             *                 50B      90B
             *              30R   60B  80B  100B
             *           20B    40B
             *         10R   
             */


        }
    }
}