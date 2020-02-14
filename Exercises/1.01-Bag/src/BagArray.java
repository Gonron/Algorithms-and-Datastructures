import java.util.Iterator;

public class BagArray<T> implements Bag<T> {

    private T[] items;
    private int size = 0;

    public BagArray(int capacity) {
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
        return new ArrayIterator();
    }

    private class ArrayIterator implements Iterator<T> {
        int index = 0;
        @Override
        public boolean hasNext() {
            return index < size;
        }
        @Override
        public T next() {
            return items[index++];
        }
    }
    public static void main(String[] args) {
        Bag b = new BagArray<Integer>(10);
        b.add(1);
        b.add(2);
        b.add(3);
        b.add(4);
        b.add(5);
        b.add(6);
        b.add(7);
        b.add(8);
        b.add(9);
        b.add(10);
        //b.add(11);
        for (Object item : b) System.out.println(item);
    }
}
