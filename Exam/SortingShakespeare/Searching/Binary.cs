using System;
using System.Collections.Generic;
using SortingShakespeare.Sorting;

namespace SortingShakespeare.Searching {
    public class Binary {
        public static int Search(string[] arr, string target, int left, int right) {
            if (left > right) {
                throw new Exception($"Target: {target} is not in the array");
            }
            var mid = (left + right) / 2;
            if (arr[mid] == target) {
                return mid;
            }

            return Utils.Less(target, arr[mid])
                ? Search(arr, target, left, mid - 1)
                : Search(arr, target, mid + 1, right);
        }
    }
}