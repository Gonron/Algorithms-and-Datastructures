import java.util.Iterator;

public class ArrayBag<T> implements Bag<T> {

    private T[] items;
    private int size = 0;

    public ArrayBag(int capacity) {
        items = (T[])(new Object[capacity]);
    }

    @Override
    public boolean isEmpty() {
        return getSize() == 0;
    }

    @Override
    public int getSize() {
        return size;
    }

    @Override
    public void add(T item) {
        items[size++] = item;
    }

    @Override
    public Iterator<T> iterator() {
        return null;
    }
}
