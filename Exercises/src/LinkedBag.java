import java.util.Iterator;

public class LinkedBag<T> implements Bag {
    private T[] items;
    private int size = 0;

    public LinkedBag() {
    }

    @Override
    public boolean isEmpty() {
        return false;
    }

    @Override
    public int getSize() {
        return 0;
    }

    @Override
    public void add(Object item) {

    }

    @Override
    public Iterator iterator() {
        return null;
    }
}
