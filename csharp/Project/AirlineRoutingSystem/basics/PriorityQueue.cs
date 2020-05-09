using System;
using System.Drawing;

namespace AirlineRoutingSystem.basics {
    public class PriorityQueue<T> where T : Dijkstra.Path {
        private T[] _items;
        private int _size;

        public PriorityQueue(int size) {
            _items = new T[size];
            _size = 0;
        }

        public void Enqueue(T item) {
            if (_size == _items.Length) 
                throw new Exception("Can't add to full queue");
            _items[_size] = item;
            _size++;
            Swim(_size - 1);
        }

        public T Dequeue() {
            if (_size == 0)
                throw new Exception("Can't remove from empty queue");
            var pop = _items[0];
            _items[0] = _items[_size - 1];
            _items[_size - 1] = default;
            _size--;
            Sink();

            return pop;
        }
        
        private void Swim(int i) {
            var parent = (i - 1) / 2;
            if (Less(_items[i], _items[parent])) {
                Swap(i, parent);
                Swim(parent);
            }
        }

        private void Sink(int i = 0) {
            var top = i;
            var left = i * 2 + 1;
            var right = i * 2 + 2;

            if (left < _size && Less(_items[left], _items[top]))
                top = left;
            if (right < _size && Less(_items[right], _items[top]))
                right = left;
            if (i != top) {
                Swap(i, top);
                Sink(top);
            }
        }

        public T Peek() {
            if (_size == 0) 
                throw new Exception("Can't peek into empty queue");
            return _items[0];
        }

        public bool IsEmpty() {
            return _size == 0;
        }
        
        private void Swap(int a, int b) {
            var temp = _items[a];
            _items[a] = _items[b];
            _items[b] = temp;
        }

        private bool Less(T a, T b) {
            return a.CompareTo(b) < 0;
        }
    }
}