namespace AirlineRoutingSystem.basics {
    public interface IQueue<T> : IContainer<T> {
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }
}