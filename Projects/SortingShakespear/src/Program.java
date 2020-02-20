import java.io.IOException;

public class Program {
    public static void main(String[] args) {
        TextProcessor tp = new TextProcessor();
        String regex = "[a-zA-ZæøåÆØÅ]+'?[a-zA-ZæøåÆØÅ]*";
        String txtPath = "C:\\Users\\lunds\\Desktop\\CPHBusiness\\soft\\Algorithms-and-Datastructures\\Projects\\SortingShakespear\\src\\shakespeare-complete-works.txt";

        tp.processTextFile(txtPath, regex);
        //System.out.println(tp.processedStrngs.size());

        Sorter sort = new Sorter();
        Stopwatch sw  = new Stopwatch();

        sw.step();
        sort.selectionSort(tp.processedStrngs);
        sw.close();
        
    }
}
