using System;
using System.Data;

namespace SortingShakespeare.Sorting {
    public class Heap {
        public static void Sort(string[] arr) {
            Console.WriteLine(
                $"\nTime Complexity: \n- Best: O(n log(n)) \n- Worst: O(n log(n)) " +
                $"\nSpace Complexity: \n- Worst O(1) \n");

            var n = arr.Length;
            BuildMaxHeap(arr, n);
            Sort(arr, n);
        }

        private static void Sort(string[] arr, int n) {
            // Sorts from the back
            for (var i = n - 1; i >= 0; i--) {
                // Swaps last ele with max
                Utils.Swap(arr, i, 0);
                SiftDown(arr, i, 0);
            }
        }

        private static void BuildMaxHeap(string[] arr, int n) {
            // Skips the leaf-nodes - We already know their parents,
            // therefor they don't need to be moved
            for (var i = n / 2 - 1; i >= 0; i--) {
                SiftDown(arr, n, i);
            }
        }

        private static void SiftDown(string[] arr, int n, int i) {
            var p = i; // Parent
            var l = i * 2 + 1; // Left-child
            var r = i * 2 + 2; // Right-child
            if (l < n && Utils.Less(arr[p], arr[l])) {
                p = l;
            }

            if (r < n && Utils.Less(arr[p], arr[r])) {
                p = r;
            }

            if (i != p) {
                Utils.Swap(arr, i, p);
                SiftDown(arr, n, p);
            }
        }
    }
}