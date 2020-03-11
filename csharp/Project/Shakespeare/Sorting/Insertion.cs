using System;

namespace Shakespeare.Sorting {
    public class Insertion {
        
        public static void Sort(IComparable[] arr) {
            var n = arr.Length;
            for (var i = 1; i < n; i++) {
                for (var j = i; j > 0 && Util.Less(arr[j], arr[j-1]); j++) {
                    Util.Exchange(arr, j, j - 1);
                } 
            }
        }

        
    }
}