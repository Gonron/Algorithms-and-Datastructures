using System;
using SortingShakespeare.Sorting;

namespace SortingShakespeare.Searching {
    public class Exponential {
        public static int Search(string[] arr, string target, int size) {
            var right = 1; // High

            while (right < size && Utils.Less(arr[right], target)) {
                right *= 2;
            }
            
            return Binary.Search(arr, target, right / 2, Math.Min(right, size));
        }
    }
} 