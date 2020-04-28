using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RegularExpression {
    public partial class Bag<T> : IEnumerable<T> {
        private T[] _bagArray = new T[4];
        private int _nextAvailableIndex = 0;

        public void Add(T item) {
            if (_bagArray.Length * 0.75 <= _nextAvailableIndex) {
                var tempArray = new T[_bagArray.Length * 2];
                for (var i = 0; i < _nextAvailableIndex; i++) {
                    tempArray[i] = _bagArray[i];
                }

                _bagArray = tempArray;
            }

            _bagArray[_nextAvailableIndex] = item;
            _nextAvailableIndex++;
        }

        public IEnumerator<T> GetEnumerator() {
            return _bagArray.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public bool IsEmpty() {
            return _nextAvailableIndex == 0;
        }

        public int GetSize() {
            return _nextAvailableIndex;
        }
    }
}