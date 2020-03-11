using System;

namespace Shakespeare.Sorting {
    public class Merge {
        private static IComparable[] aux;

        public static void Sort(IComparable[] arr) {
            // Bottom-up Mergesort
            var N = arr.Length;
            aux = new IComparable[N];
            for (var sz = 1; sz < N; sz += sz) { // sz: subarray size
                for (var lo = 0; lo < N - sz; lo += sz + sz) { // lo: subarray index
                    Merger(arr, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, N - 1));
                }
            }
        }

        private static void Merger(IComparable[] arr, int low, int mid, int high) {
            // Merge arr[low ... mid] with arr[mid + 1 ... high]
            var i = low;
            var j = mid + 1;

            for (var k = low; k <= high; k++) {
                // Copy arr[low ... high] to aux[low ... high]
                aux[k] = arr[k];
            }

            for (var k = low; k <= high; k++) {
                // Merge back to arr[low ... high]
                if (i > mid) arr[k] = aux[j++];
                else if (j > high) arr[k] = aux[i++];
                else if (Util.Less(aux[j], aux[i])) arr[k] = aux[j++];
                else arr[k] = aux[i++];
            }

        }
    }
}