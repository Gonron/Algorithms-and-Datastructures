using System;
using System.Collections;

namespace ArraySorter {
    public class ArraySorter<T> where T : IComparable<T> {
        public T[] Queue { get; }
        public int HeapSize { get; private set; }
        private bool _isSortedAscending;
        private int MaxHeapSize { get; }

        public ArraySorter(T[] items, int heapSize) {
            Queue = new T[heapSize];
            HeapSize = items.Length;
            MaxHeapSize = heapSize;
            // Copying the context of itemsArray to the Queue
            for (var i = 0; i < items.Length; i++) {
                Queue[i] = items[i];
            }
        }

        public void Enqueue(T item) {
            if (HeapSize == MaxHeapSize) {
                throw new Exception("Queue is full");
            }

            Queue[HeapSize++] = item;

            if (_isSortedAscending) {
                BuildHeap((x, y) => x.CompareTo(y) < 0);
            }
            else {
                BuildHeap((x, y) => x.CompareTo(y) > 0);
            }
        }

        public T Dequeue() {
            if (HeapSize == 0) {
                throw new Exception("Queue is empty, can't dequeue.");
            }

            var root = Queue[0];

            // Move last element to the root
            Queue[0] = Queue[--HeapSize];
            Queue[HeapSize] = default;

            if (_isSortedAscending) {
                BuildHeap((x, y) => x.CompareTo(y) < 0);
            }
            else {
                BuildHeap((x, y) => x.CompareTo(y) > 0);
            }

            return root;
        }

        public void SortAscending() {
            Sort((x, y) => x.CompareTo(y) > 0);
        }

        public void SortDescending() {
            Sort((x, y) => x.CompareTo(y) < 0);
        }

        private void Sort(Func<T, T, bool> lambda) {
            var length = HeapSize;
            BuildHeap(lambda);
            for (var i = length - 1; i >= 0; i--) {
                // Move current root to end
                Exch(Queue, 0, i);
                // Heapify the reduced heap
                Heapify(Queue, i, 0, lambda);
            }

            // Get the sorting order by comparing root to the last element
            _isSortedAscending = Queue[0].CompareTo(Queue[HeapSize - 1]) < 0;
        }

        private void BuildHeap(Func<T, T, bool> lambda) {
            for (var i = HeapSize / 2 - 1; i >= 0; i--) {
                Heapify(Queue, HeapSize, i, lambda);
            }
        }

        public void Heapify(T[] arr, int size, int i, Func<T, T, bool> lambda) {
            var parent = i;
            var leftChild = i * 2 + 1;
            var rightChild = i * 2 + 2;

            if (leftChild < size && lambda(arr[leftChild], arr[parent])) {
                parent = leftChild;
            }

            if (rightChild < size && lambda(arr[rightChild], arr[parent])) {
                parent = rightChild;
            }

            if (parent != i) {
                Exch(arr, i, parent);
                Heapify(arr, size, parent, lambda);
            }
        }

        private void Exch(T[] arr, int a, int b) {
            var temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}