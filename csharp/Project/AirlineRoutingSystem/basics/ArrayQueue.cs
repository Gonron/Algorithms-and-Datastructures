using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AirlineRoutingSystem.basics {
    public class ArrayQueue<T> : IQueue<T> {

        private T[] _items;
        private int _start;
        private int _end;

        public ArrayQueue(int capacity) {
            _items = new T[capacity];
        }

        public int GetSize() {
            return _end - _start;
        }

        public void Enqueue(T item) {
            _items[_end++] = item;
            _end %= _items.Length;
        }

        public T Dequeue() {
            var item = _items[_start++];
            _start %= _items.Length;
            return item;
        }

        public T Peek() {
            throw new System.NotImplementedException();
        }
        public IEnumerator<T> GetEnumerator() {
            return _items.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}