using System;
using System.Diagnostics.Tracing;
using System.Threading;

namespace Shakespeare.Sorting {
    public class Heap {
        public static void Sort(IComparable[] arr) {
            var length = arr.Length;

            for (var i = arr.Length / 2 - 1; i >= 0; i--) {
                Heapify(arr, length, i);
            }

            for (var i = arr.Length - 1; i >= 0; i--) {
                Util.Exchange(arr, i, 0);
                Heapify(arr, i, 0);
            }
        }

        private static void Heapify(IComparable[] arr, int n, int i) {
            var largest = i;
            var left = i * 2 + 1;
            var right = i * 2 + 2;

            if (left < n && Util.Less(arr[largest], arr[left])) {
                largest = left;
            }

            if (right < n && Util.Less(arr[largest], arr[right])) {
                largest = right;
            }

            if (i != largest) {
                Util.Exchange(arr, i, largest);
                Heapify(arr, n, largest);
            }
        }
    }
}