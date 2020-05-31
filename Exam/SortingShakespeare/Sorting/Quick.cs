using System;
using System.Collections.Concurrent;
using System.Data;

namespace SortingShakespeare.Sorting {
    public class Quick {
        public static void Sort(string[] arr, bool reverse = false) {
            Console.WriteLine($"\nTime Complexity: \n- Best: O(n log(n)) \n- Worst: O(n\xB2) \nSpace Complexity: \n- Worst O(log(n)) \n");
            var n = arr.Length;
            Sort(arr, 0, n - 1);
        }

        private static void Sort(string[] arr, int left, int right) {
            if (left < right) {
                var pivot = Partition(arr, left, right);
                if (pivot > 1)
                    Sort(arr, left, pivot - 1);
                if (pivot + 1 < right)
                    Sort(arr, pivot + 1, right);
            }
        }

        private static int Partition(string[] arr, int left, int right) {
            var pivot = arr[left];
            while (true) {
                while (Utils.Less(arr[left], pivot))
                    left++;

                while (Utils.Less(pivot, arr[right]))
                    right--;
                
                if (left < right) {
                    Utils.Swap(arr, left, right);
                }
                else {
                    return right;
                }
            }
        }
    }
}