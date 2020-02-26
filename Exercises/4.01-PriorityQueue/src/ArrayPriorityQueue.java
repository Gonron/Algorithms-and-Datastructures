import util.ArrayIterator;

import java.util.Iterator;
import java.util.NoSuchElementException;

public class ArrayPriorityQueue<T extends Comparable<T>> implements PriorityQueue<T> {
    private T[] items;
    private int end = 20;

    @Override
    public boolean isEmpty() {
        return false;
    }

    @Override
    public int getSize() {
        return 0;
    }

    @Override
    public void enqueue(T item) {

    }

    @Override
    public T dequeue() throws NoSuchElementException {
        return null;
    }

    @Override
    public T peek() throws NoSuchElementException {
        return null;
    }

    @Override
    public Iterator<T> iterator() {
        return new ArrayIterator<T>(items,end);
    }
}
