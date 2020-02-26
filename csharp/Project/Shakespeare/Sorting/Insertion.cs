using System;

namespace Shakespeare.Sorting {
    public class Insertion {
        
        public static void Sort(IComparable[] arr) {
            var n = arr.Length;
            for (int i = 1; i < n; i++) {
                for (int j = i; j > 0 && Less(arr[j], arr[j-1]); j++) {
                    Exch(arr, j, j - 1);
                } 
            }
        }

        private static bool Less(IComparable v, IComparable w) {
            return v.CompareTo(w) < 0;
        }

        private static void Exch(IComparable[] arr, int i, int j) {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private static void Show(IComparable[] arr) {
            foreach (var t in arr) {
                Console.Write(t + " ");
            }
        }

        public static bool isSorted(IComparable[] arr) {
            for (int i = 1; i < arr.Length; i++) {
                if (Less(arr[i], arr[i - 1])) {
                    return false;
                }
            }

            return true;
        }
    }
}