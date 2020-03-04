using System;
using System.Globalization;
using System.IO;

namespace Searches {
    public class Exponential {
        private readonly string[] _text;
        private long _comparisonCount;
        private readonly long _target;
        
        public Exponential(string path) {
            _text = File.ReadAllLines(path);
            _comparisonCount = 0;
            _target = 50113299;
        }

        public int Search() {
            var textLong = Array.ConvertAll(_text, long.Parse);
            if (Compare(_target, textLong[0]) == 0) {
                return 0;
            }
            for (var i = 1; i < textLong.Length; i++) {
                var compare = Compare(_target, textLong[PowerOfTwo(i)]);
                // Console.WriteLine(_comparisonCount);
                if (compare == -1) {
                    // compare is larger then _target
                    var index = BinarySearch(PowerOfTwo(i - 1), PowerOfTwo(i), textLong);
                    Console.WriteLine("Found the target number: " + _target + " on index: " + index + " after " + _comparisonCount + " attempts");
                    return index;
                }
            }
            // Doing this instead of throwing a custom exception
            return -1;
        }

        private int BinarySearch(int min, int max, long[] array) {
            var mid = (min + max) / 2;
            var compare = Compare(_target, array[mid]);
            // Console.WriteLine(_comparisonCount);
            if (compare == -1) {
                mid = BinarySearch(min, mid, array);
            }
            if (compare == 1) {
                mid = BinarySearch(mid, max, array);
            }
            return mid;
        }
        
        private int PowerOfTwo(int n) {
            // Shift-left
            return 1 << n;
        }
        
        private long Compare(long a, long b) {
            _comparisonCount++;
            return a > b ? 1 : a == b ? 0 : -1;
        }
    }
    
}