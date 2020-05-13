using System;

namespace PriorityQueue.interfaces {
    public interface IPriorityQueue<T>: ISelection<T> where T: IComparable<T>
    {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }
}