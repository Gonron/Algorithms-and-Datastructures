using System;
using System.Collections.Generic;
using SortingShakespeare.Sorting;

namespace SortingShakespeare.Other {
    public class MinHeap {
        private string[] arr;
        private int _arrSize; // Size of the array
        private int _heapSize; // Number of elements

        public MinHeap() {
            _arrSize = 0;
            _heapSize = 0;
            arr = new string[_arrSize];
        }

        public MinHeap(int size) {
            arr = new string[size];
        }

        public void SetHeapSize(int size) {
            _arrSize = size;
            arr = new string[size];
        }

        public void Insert(string value) {
            if (_heapSize == arr.Length) {
                throw new Exception("Heap is full");
            }
            arr[_heapSize] = value;
            _heapSize++;
            SiftUp(_heapSize - 1);
        }

        public void Remove(string value) {
            for (var i = 0; i < _heapSize; i++) {
                if (arr[i] == value) {
                    arr[i] = arr[_heapSize - 1];
                    _heapSize--;
                    SiftDown(i);
                    break;
                }
            }
        }

        private void SiftUp(int idx) {
            if (idx != 0) {
                var pIdx = (idx - 1) / 2;
                if (Utils.Less(arr[idx], arr[pIdx])) {
                    Utils.Swap(arr, pIdx, idx);
                    SiftUp(pIdx);
                }
            }

        }
        
        private void SiftDown(int idx) {
            var p = idx; // Parent
            var l = idx * 2 + 1; // Left-child
            var r = idx * 2 + 2; // Right-child
            if (l < _heapSize && Utils.Less(arr[l], arr[p])) {
                p = l;
            }

            if (r < _heapSize && Utils.Less(arr[r], arr[p])) {
                p = r;
            }

            if (idx != p) {
                Utils.Swap(arr, idx, p);
                SiftDown(p);
            }
        }

        public void BuildHeap(string[] input) {
            if (_heapSize > 0) {
                // Clear the current heap
                Array.Resize(ref arr, input.Length);
                _heapSize = 0;
                for (var i = 0; i < arr.Length; i++) {
                    arr[i] = input[i];
                    _heapSize++; 
                }
            }
            for (var i = _heapSize / 2 - 1; i >= 0; i--) {
                SiftDown(i);
            }
        }
        
        public void DisplayHeap() {
            Console.WriteLine("Elements of the heap:");
            for (var i = 0; i < _heapSize; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
        }

        
    }
}