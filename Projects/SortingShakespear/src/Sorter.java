import java.util.List;

public class Sorter {

    public static List<String> selectionSort(List<String> list) {
        for (int i = 0; i < list.size(); i++) {
            for (int j = 0; j < list.size(); j++) {
                if (list.get(i).compareTo(list.get(j)) < 0) {
                    String temp = list.get(j);
                    list.set(j, list.get(i));
                    list.set(i, temp);
                }
            }

        }
        return list;
    }

    public static String[] sort(String[] a) {
        for (int i=0; i<a.length-1; i++) {
            for (int j=0; j<a.length; j++) {
                if (a[i].compareTo(a[j]) < 0) {
                    String temp=a[j];
                    a[j]=a[i];
                    a[i]=temp;
                }
            }
        }
        return a;
    }
}
