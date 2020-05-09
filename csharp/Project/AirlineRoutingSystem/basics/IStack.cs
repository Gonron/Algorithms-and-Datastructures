namespace AirlineRoutingSystem.basics {
    public interface IStack<T> : IContainer<T> {
        void Push(T item);
        T Pop();
        T Peek();
    }
}