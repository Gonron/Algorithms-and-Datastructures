using System;

namespace ArraySorter {
    public class ArraySorter<T> {
        private T[] items;
        private int size;

        public ArraySorter(T[] items, int size) {
            this.items = items;
            this.size = size;
        }

        public void Enqueue(T item) {
            throw new NotImplementedException();
        }

        public T Dequeue() {
            throw new NotImplementedException();
        }

        public void SortAscending() {
            throw new NotImplementedException();
        }

        public void SortDescending() {
            
        }

        public void Sort(T IComparable) {
            
        }
    }
}