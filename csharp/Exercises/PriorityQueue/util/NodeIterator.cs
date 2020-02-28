using System.Collections;
using System.Collections.Generic;

namespace PriorityQueue.util {
    public class NodeIterator<T> : IEnumerator<T> {
        private Node<T> _step;
        private readonly Node<T> _initialValue;

        public NodeIterator(Node<T> first) {
            this._step = first;
            _initialValue = first;
        }

        public bool HasNext() {
            return _step != null;
        }

        public bool MoveNext() {
            _step = _step.Next;
            return HasNext();
        }

        public void Reset() {
            _step = _initialValue;
        }

        public T Current => _step.Value;

        object? IEnumerator.Current => Current;

        public void Dispose() {
            _step = null;
        }
    }
}