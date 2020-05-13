using System.Collections.Generic;
namespace AirlineRoutingSystem.basics {
    public interface IContainer<T> : IEnumerable<T> {
        int GetSize();
        bool IsEmpty() {
            return GetSize() == 0;
        }
    }
}