using System;

namespace AirportQueueSystem.Queue {
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable<T> {
        public T[] Items { get; private set; }
        public int Size { get; private set; }

        public PriorityQueue(int size) {
            Items = new T[size];
            Size = 0;
            BuildHeap();
        }

        private void BuildHeap() {
            var length = Size;
            for (var i = length / 2 - 1; i >= 0; i--) {
                Heapify(length, i);
            }
        }

        private void Heapify(int length, int i) {
            int largest = i;

            var left = i * 2 + 1;
            var right = i * 2 + 2;

            if (left < length && Less(Items[largest], Items[left])) {
                largest = left;
            }

            if (right < length && Less(Items[largest], Items[right])) {
                largest = right;
            }

            if (i != largest) {
                Swap(i, largest);
                Heapify(length, largest);
            }
        }

        public void Enqueue(T item) {
            IncreaseSize();
            Items[Size] = item;
            Size++;
            BuildHeap();
        }

        private void IncreaseSize() {
            if (Size + 1 > Items.Length * 0.75) {
                var newArr = new T[Items.Length * 2];
                for (var i = 0; i < Size; i++) {
                    newArr[i] = Items[i];
                }

                Items = newArr;
            }
        }

        public T Dequeue() {
            var pop = Items[0];
            Items[0] = Items[Size - 1];
            Items[Size - 1] = default(T);
            Size--;
            Heapify(Size - 1, 0);
            return pop;
        }

        public T Peek() {
            if (Size == 0)
                throw new InvalidOperationException("Cannot peek into empty queue");
            return Items[Size];
        }

        public bool IsEmpty() {
            return Size == 0;
        }

        private void Swap(int idxA, int idxB) {
            var tmp = Items[idxA];
            Items[idxA] = Items[idxB];
            Items[idxB] = tmp;
        }

        private static bool Less(T first, T second) {
            return first.CompareTo(second) > 0;
        }
    }
}