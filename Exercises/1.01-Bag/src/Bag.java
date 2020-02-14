interface Selection <T> extends Iterable <T> {
    boolean isEmpty ();
    int getSize ();
}
interface Bag <T> extends Selection <T> {
    void add (T item );
}