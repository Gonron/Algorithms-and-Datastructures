using System;
using System.IO;

namespace Searches {
    public class Sequential {
        private readonly string[] _text;
        private long _comparisonCount;
        private readonly long _target;

        public Sequential(string path) {
            _text = File.ReadAllLines(path);
            _comparisonCount = 0;
            _target = 50113299;
        }

        public int Search() {
            var textLong = Array.ConvertAll(_text, long.Parse);
            for (var i = 0; i < textLong.Length; i++) {
                var compare = Compare(textLong[i], _target);
                if (compare == 0) {
                    Console.WriteLine("Found the target number: " + _target + " on index: " + i + " after " + _comparisonCount + " attempts");
                    return i;
                }
            }
            // Doing this instead of throwing a custom exception
            return -1;
        }
        
        private long Compare(long a, long b) {
            _comparisonCount++;
            return a > b ? 1 : a == b ? 0 : -1;
        }
        
        
        
        

        
    }
}