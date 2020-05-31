using System;

namespace SortingShakespeare.Sorting {
    public class Insertion {
        public static void Sort(string[] arr, bool reverse = false) {
            Console.WriteLine(
                $"\nTime Complexity: \n- Best: O(n) \n- Worst: O(n\xB2) " +
                $"\nSpace Complexity: \n- Worst O(1) \n");
            
            var n = arr.Length;
            for (var i = 1; i < n; i++) {
                // Swap the elements in 'less' to reverse the sort
                if (!reverse) { // MinSort
                    for (var j = i; j > 0 && Utils.Less(arr[j], arr[j - 1]); j--) {
                        Utils.Swap(arr, j, j - 1);
                    }
                }
                else { // MaxSort
                    for (var j = i; j > 0 && Utils.Less(arr[j - 1], arr[j]); j--) {
                        Utils.Swap(arr, j, j - 1);
                    }
                }
            }
        }
    }
}