interface Selection <T> extends Iterable <T> {
    boolean isEmpty ();
    int getSize ();
}
interface Queue <T> extends Selection <T> {
    void enqueue (T item );
    T dequeue ();
}