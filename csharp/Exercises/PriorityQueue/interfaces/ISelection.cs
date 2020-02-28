using System.Collections.Generic;

namespace PriorityQueue.interfaces {
    public interface ISelection<T> : IEnumerable<T> {
        bool IsEmpty();
        int GetSize();
    }
}