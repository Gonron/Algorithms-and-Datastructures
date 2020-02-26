import java.util.Iterator;

public class QueueLinked<T> implements Queue<T> {
    private Node first; // Link to last added node
    private Node last; // Link to newest added node
    private int N;

    private class Node {
        T item;
        Node next;
    }

    @Override
    public boolean isEmpty() {
        return first == null;
    }

    @Override
    public int getSize() {
        return N;
    }

    @Override
    public void enqueue(T item) {
        // Add item to back of queue
        Node oldLast = last;
        last = new Node();
        last.item = item;
        last.next = null;
        if (isEmpty()) {
            first = last;
        } else {
            oldLast.next = last;
        }
        N++;
    }

    @Override
    public T dequeue() {
        // Remove item from front of queue
        T item = first.item;
        first = first.next;
        if (isEmpty()) {
            last = null;
        }
        ;
        N--;
        return item;
    }

    @Override
    public Iterator<T> iterator() {
        return new QueueIterator();
    }

    private class QueueIterator implements Iterator<T> {
        private Node step = first;
        @Override
        public T next() {
            T item = step.item;
            step = step.next;
            return item;
        }
        @Override
        public boolean hasNext() {
            return step != null;
        }
    }

    public static void main(String[] args) {
        Queue q = new QueueLinked<String>();

        q.enqueue(1);
        q.enqueue(2);
        q.enqueue(3);
        q.dequeue();

        System.out.println(q.getSize());
        System.out.println(q.isEmpty());

    }
}
