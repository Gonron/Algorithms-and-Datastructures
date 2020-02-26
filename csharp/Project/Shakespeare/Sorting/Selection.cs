using System;

namespace Shakespeare.Sorting {
    public class Selection {

        public static void Sort(IComparable[] arr) {
            var n = arr.Length;
            for (int i = 0; i < n; i++) {
                var min = i;
                for (int j = i+1; j < n; j++) {
                    if (Less(arr[j], arr[min])) {
                        min = j;
                    }
                }
                Exch(arr,i,min);
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
                if (Less(arr[i], arr[i-1])) {
                    return false;
                }
            } 
            return true;
        }
    }
}