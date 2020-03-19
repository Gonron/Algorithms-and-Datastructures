using System;

namespace AirportQueueSystem.Queue {
    public interface IPriorityQueue<T> : IQueue<T> where T : IComparable<T> { }
}