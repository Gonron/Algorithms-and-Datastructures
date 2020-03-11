using System;

namespace Shakespeare.Sorting {
    public class Selection {

        public static void Sort(string[] arr) {
            var n = arr.Length;
            for (var i = 0; i < n; i++) {
                var min = i;
                for (var j = i+1; j < n; j++) {
                    if (Util.Less(arr[j], arr[min])) {
                        min = j;
                    }
                }
                Util.Exchange(arr,i,min);
            }
        }
    }
}