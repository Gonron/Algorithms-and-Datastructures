using System;

namespace SortingShakespeare.Sorting {
    public class Selection {
        public static void Sort(string[] arr, bool reverse = false) {
            Console.WriteLine(
                $"\nTime Complexity: \n- Best: O(n\xB2) \n- Worst: O(n\xB2) " +
                $"\nSpace Complexity: \n- Worst O(1) \n");
            
            var n = arr.Length;
            for (var i = 0; i < n - 1; i++) { // Current min
                var pointer = i;
                for (var j = i + 1; j < n; j++) { // Current item
                    // Swap the elements in 'less' to reverse the sort
                    if (!reverse) { // MinSort
                        if (Utils.Less(arr[j], arr[pointer]))
                            pointer = j;
                    }
                    else { // MaxSort
                        if (Utils.Less(arr[pointer], arr[j]))
                            pointer = j;
                    }
                }

                if (pointer != i)
                    Utils.Swap(arr, i, pointer);
            }
        }
    }
}