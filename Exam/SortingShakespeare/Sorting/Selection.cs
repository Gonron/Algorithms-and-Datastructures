namespace SortingShakespeare.Sorting {
    public class Selection {

        public static void Sort(string[] arr, bool reverse = false) {
            var n = arr.Length;
            for (var i = 0; i < n-1; i++) {
                var pointer = i;
                for (var j = i+1; j < n; j++) {
                    // Swap the elements in less to reverse the sort
                    if (reverse == false) { // MinSort
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