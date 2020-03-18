using System;
using System.ComponentModel.DataAnnotations;

namespace BalancedSearchTree {
    class Program {
        private static void Main(string[] args) {
            var RB = new RedBlackTree<int, int>();
            var Values = new[] {100, 30, 20, 90, 80, 70, 40, 60, 50, 10, 100};
            //var values = new[] {10, 20, 30, 40, 50, 60, 70, 80, 90, 100};
            
            for (var i = 0; i < Values.Length; i++) {
                RB.Put(Values[i], i);
            }

            var x = RB._root;
            Console.WriteLine("Key: " + x.Key);
            Console.WriteLine("Value: " + x.Value);
            Console.WriteLine("Color: " + (x.Color ? "RED" : "BLACK"));

            /*
             *                      70B
             *               50B           90B
             *            30R   60B     80B  100B
             *         20B    40B
             *      10R   
             */
        }
    }
}