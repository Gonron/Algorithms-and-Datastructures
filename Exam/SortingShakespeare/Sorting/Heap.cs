using System;

namespace SortingShakespeare.Sorting {
    public class Heap {
        public static void Sort(string[] arr, bool reverse = false) {
            Console.WriteLine($"\nTime Complexity: \n- Best: O(n log(n)) \n- Worst: O(n log(n)) \nSpace Complexity: \n- Worst O(1) \n");
            var n = arr.Length;

            for (var i = n / 2 - 1; i >= 0; i--) {
                if (!reverse) { // MinSort
                    MinHeapify(arr, n, i);
                }
                else { // MaxSort
                    MaxHeapify(arr, n, i);
                }
            }

            for (var i = n - 1; i >= 0; i--) {
                Utils.Swap(arr, i, 0);
                if (!reverse) { // MinSort
                    MinHeapify(arr, i, 0);
                }
                else { // MaxSort
                    MaxHeapify(arr, i, 0);
                }
            }
        }

        private static void MinHeapify(string[] arr, int n, int i) {
            var min = i;
            var l = i * 2 + 1;
            var r = i * 2 + 2;

            if (l < n && Utils.Less(arr[min], arr[l])) {
                min = l;
            }

            if (r < n && Utils.Less(arr[min], arr[r])) {
                min = r;
            }

            if (i != min) {
                Utils.Swap(arr, i, min);
                MinHeapify(arr, n, min);
            }
        }

        private static void MaxHeapify(string[] arr, int n, int i) {
            var max = i;
            var l = i * 2 + 1;
            var r = i * 2 + 2;

            if (l < n && Utils.Less(arr[l], arr[max])) {
                max = l;
            }

            if (r < n && Utils.Less(arr[r], arr[max])) {
                max = r;
            }

            if (i != max) {
                Utils.Swap(arr, i, max);
                MaxHeapify(arr, n, max);
            }
        }
    }
}