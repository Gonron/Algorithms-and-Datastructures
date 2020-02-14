import java.util.Iterator;

public class BagLinked<T> implements Bag<T> {
    private Node first = null;

    private class Node {
        T item;
        Node next;
        Node(T item, Node next){
            this.item = item;
            this.next = next;
        }
        int length() {
            if (next == null) return 1;
            return next.length() + 1;
        }
    }
    @Override
    public boolean isEmpty() {
        return getSize() == 0;
    }

    @Override
    public int getSize() {
        return first == null ? 0 : first.length();
    }

    @Override
    public void add(T item) {
        first = new Node(item, first);

    }

    @Override
    public Iterator<T> iterator() {
        return new LinkedIterator();
    }

    private class LinkedIterator implements Iterator<T> {
        private Node step = first;
        @Override
        public T next() {
            T item = step.item;
            step = step.next;
            return item;
        }
        @Override
        public boolean hasNext() { return step != null; }
    }

    public static void main(String[] args) {
        Bag b = new BagLinked<Integer>();
        b.add(1);
        b.add(2);
        b.add(3);
        b.add(4);
        b.add(5);
        b.add(6);
        for (Object item : b) System.out.println(item);
    }
}
