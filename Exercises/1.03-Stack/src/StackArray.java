import java.util.Iterator;

public class StackArray<T> implements Stack<T> {
    private T[] arr = (T[])(new Object[1]);
    private int N = 0;

    @Override
    public boolean isEmpty() {
        return N == 0;
    }

    @Override
    public int getSize() {
        return N;
    }

    private void resize(int max) {
        T[] temp = (T[])(new Object[max]);
        for (int i = 0; i < N ; i++) {
            temp[i] = arr[i];
        }
        arr = temp;
    }

    @Override
    public void push(T item) {
        if (N == arr.length) {
            resize(2 * arr.length);
        }
        arr[N++] = item;
    }

    @Override
    public T pop() {
        T item = arr[N--];
        arr[N] = null;
        if (N > 0 && N == arr.length/4) {
            resize(arr.length/2);
        }
        return item;
    }

    @Override
    public Iterator<T> iterator() {
        return new ReverseArrayIterator();
    }

    private class ReverseArrayIterator implements Iterator<T> {
        private int i = N;
        public boolean hasNext() {
            return i > 0;
        }
        public T next() {
            return arr[--i];
        }
    }

    public static void main(String[] args) {
        Stack st = new StackArray<Integer>();

        st.push(1);
        st.push(2);
        st.push(3);

        st.pop();
        System.out.println(st.isEmpty());
        System.out.println(st.getSize());
    }
}
