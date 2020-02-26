import java.util.Iterator;

public class StackLinked<T> implements Stack<T> {

    private Node first; // Top of stack
    private int N; // Number of items

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
    public void push(T item) {
        // Adding item to top of stack.
        Node oldFirst = first;
        first = new Node();
        first.item = item;
        first.next = oldFirst;
        N++;
    }

    @Override
    public T pop() {
        // Remove item from top of stack
        T item = first.item;
        first = first.next;
        N--;
        return item;
    }

    @Override
    public Iterator<T> iterator() {
        return new StackIterator();
    }

    private class StackIterator implements Iterator<T> {
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
        Stack st = new StackLinked<Integer>();

        st.push(1);
        st.push(2);
        st.push(3);

        st.pop();
        System.out.println(st.isEmpty());
        System.out.println(st.getSize());
    }
}
