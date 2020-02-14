import java.util.Iterator;

public class QueueArray<T> implements Queue<T> {
    private int front, rear, capacity;
    private int size = 0;
    private T[] queue;

    public QueueArray(int capacity) {
        this.capacity = capacity;
        queue = (T[])(new Object[capacity]);
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
    public void enqueue(T item) {
      if (size == capacity) {
          System.out.println("\nQueue Is Full\n");
      } else {
          queue[rear] = item;
          rear ++;
          size ++;

      }
    }

    @Override
    public T dequeue() {
        if (size == 0) {
            System.out.println("\nQueue Is Empty\n");
        } else {
            front ++;
            if (front == capacity -1) {
                front = 0;
            }
            size --;
            rear --;
        }
        return queue[front];
    }

    @Override
    public Iterator<T> iterator() {
        return new QueueIterator();
    }

    private class QueueIterator implements Iterator<T> {
        int index = 0;
        @Override
        public boolean hasNext() {
            return index < size;
        }
        @Override
        public T next() {
            return queue[index++];
        }
    }

    public static void main(String[] args) {
        Queue q = new QueueArray<Integer>(10);

        q.enqueue(1);
        q.enqueue(2);
        q.enqueue(3);
        q.dequeue();

        System.out.println(q.getSize());
        System.out.println(q.isEmpty());


    }
}
