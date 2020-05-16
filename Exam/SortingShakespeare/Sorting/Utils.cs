using System;
using System.Collections.Generic;

namespace SortingShakespeare.Sorting {
    public class Utils {
        public static bool Less(IComparable v, IComparable w) {
            return v.CompareTo(w) < 0;
        }

        public static void Swap(string[] arr, int i, int j) {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static void Show(IEnumerable<string> arr) {
            foreach (var t in arr) {
                Console.Write(t + " ");
            }
        }

        public static bool isSorted(IComparable[] arr) {
            for (var i = 1; i < arr.Length; i++) {
                if (Less(arr[i], arr[i - 1])) {
                    return false;
                }
            }

            return true;
        }
    }
}