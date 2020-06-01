using System;

namespace SortingShakespeare.Sorting {
    public class Merge {
        private static string[] _temp; // Temp array for merges

        public static void Sort(string[] arr) {
            Console.WriteLine(
                $"\nTime Complexity: \n- Best: O(n log(n)) \n- Worst: O(n log(n)) " +
                $"\nSpace Complexity: \n- Worst O(n)\n");
            
            var n = arr.Length;
            _temp = new string[n]; // Allocates space
            Sort(arr, 0, n - 1);
        }

        private static void Sort(string[] arr, int low, int high) {
            if (high <= low) return;
            var mid = low + (high - low) / 2;
            Sort(arr, low, mid); // Sorts left half
            Sort(arr, mid + 1, high); // Sorts right half
            MergeArrays(arr, low, mid, high); // Merges results 
        }

        private static void MergeArrays(string[] arr, int low, int mid, int high) {
            // Merges arr[low... mid] with arr[mid+1... high]
            var i = low;
            var j = mid + 1;

            for (var k = low; k <= high; k++) {
                // Copy arr to _temp
                _temp[k] = arr[k];
            }

            for (var k = low; k <= high; k++) {
                // Merge 
                if (i > mid) {
                    arr[k] = _temp[j++];
                }
                else if (j > high) {
                    arr[k] = _temp[i++];
                }
                else if (Utils.Less(_temp[j], _temp[i])) {
                    arr[k] = _temp[j++];
                }
                else {
                    arr[k] = _temp[i++];
                }
            }
        }
    }
}