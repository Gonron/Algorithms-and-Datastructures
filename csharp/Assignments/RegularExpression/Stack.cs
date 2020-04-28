using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RegularExpression {
    public class Stack<T> : IEnumerable<T> {

        private T[] _arr = new T[4];
        private int _size;

        public bool IsEmpty() {
            return Size() == 0;
        }

        public int Size() {
            return _size;
        }

        private void Resize(int max) { // Move stack to a new array of size max
            var temp = new T[max];
            for (var i = 0; i < _size; i++) {
                temp[i] = _arr[i];
            }
            _arr = temp;
        }

        public void Push(T item) { // Add item to top of stack
            if (_size == _arr.Length) Resize(2 * _arr.Length);
            _arr[_size++] = item;
        }

        public T Pop() { // Remove item from top of stack
            var item = _arr[_size--];
            _arr[_size] = default(T); // Avoid loitering
            if (_size > 0 && _size == _arr.Length / 4) Resize(_arr.Length / 2);
            return item;
        }
        
        public IEnumerator<T> GetEnumerator() {
            return _arr.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}