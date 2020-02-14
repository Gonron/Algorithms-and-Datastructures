interface Selection <T> extends Iterable <T> {
    boolean isEmpty ();
    int getSize ();
}
interface Stack <T> extends Selection <T> {
    void push (T item );
    T pop ();
}