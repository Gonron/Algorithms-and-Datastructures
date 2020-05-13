using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AirlineRoutingSystem.basics {
    public class ArrayStack<T> : IStack<T> {

        private readonly T[] _items;
        private int _top;

        public ArrayStack(int capacity) {
            _items = new T[capacity];
        }

        public int GetSize() {
            return _top;
        }

        public void Push(T item) {
            _items[_top++] = item;
        }

        public T Pop() {
            return _items[--_top];
        }

        public T Peek() {
            return _items[_top - 1];
        }
        
        public IEnumerator<T> GetEnumerator() {
            return _items.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}