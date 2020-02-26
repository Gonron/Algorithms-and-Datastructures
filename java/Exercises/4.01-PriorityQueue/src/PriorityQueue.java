import java.util.NoSuchElementException;

interface Selection <T> extends Iterable <T> {
    boolean isEmpty ();
    int getSize ();
}

interface PriorityQueue <T extends Comparable<T> > extends Selection<T> {
    void enqueue (T item );
    T dequeue () throws NoSuchElementException;
    T peek () throws NoSuchElementException ;
}