using System;
using SortingShakespeare.Sorting;

namespace SortingShakespeare.Other {
    public class PriorityQueue<T> where T : IComparable<T> {
        private T[] _pq;
        private int _size;

        public PriorityQueue(int maxSize) {
            _pq = new T[maxSize + 1];
            _size = 0;
        }

        public bool IsEmpty() {
            return _size == 0;
        }

        public int Size() {
            return _size;
        }

        public void Enqueue(T value) {
            if (_size == _pq.Length) {
                throw new Exception("Can not add to a full queue");
            }

            _pq[_size] = value; // Adds a new value to the end
            _size++; // Counting up the size
            SiftUp(_size - 1); // Sifting up to ensure heap
        }

        public T Dequeue() {
            if (_size == 0) {
                throw new Exception("Can not remove from an empty queue");
            }
            var top = _pq[0];
            _pq[0] = _pq[_size - 1]; // Setting next T in the array as top
            _pq[_size - 1] = default(T); // Setting the "empty" T as default
            _size--; // Counting down the size;
            SiftDown(); // Sifting down to ensure heap
            
            return top;
        }

        private void SiftUp(int idx) { 
            // Checks if current idx is less then parent
            // If true, then swap
            var p = (idx - 1) / 2;
            if (Less(idx, p)) {
                Swap(idx, p);
                SiftUp(p);
            }
        }

        private void SiftDown(int idx = 0) {
            // Checks if children are less then parents
            // If true, swap the largest of the two with parent
            var p = idx; // Parent
            var l = idx * 2 + 1; // Left-child
            var r = idx * 2 + 2; // Right-child
            if (l < _size && Less(l, p)) {
                p = l;
            }

            if (r < _size && Less(r, p)) {
                p = r;
            }

            if (idx != p) {
                Swap(idx, p);
                SiftDown(p);
            }
        }

        private bool Less(int i, int j) {
            return _pq[i].CompareTo(_pq[j]) < 0;
        }

        private void Swap(int i, int j) {
            var temp = _pq[i];
            _pq[i] = _pq[j];
            _pq[j] = temp;
        }

        public void DequeueAll() {
            Console.WriteLine("\nThe Queue:");
            for (var i = 0; i < _pq.Length; i++) {
                Console.Write("{0} ", Dequeue());
            }
        }
    }
}