import java.io.*;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class TextProcessor {
    public List<String> processedStrngs = new ArrayList<String>();

    private static String readText(String path) {
        StringBuilder content = new StringBuilder();
        String line;
        try {

            FileReader fr = new FileReader(path);
            BufferedReader br = new BufferedReader(fr);
            while ((line = br.readLine()) != null) {
                content.append(line);
            }
            br.close();
        } catch (Exception e) {
            System.out.println("An error occurred.");
            e.printStackTrace();
        }
        return content.toString();
    }

    private List<String> sanitizeText(String text, String regexPattern)  {
        Pattern p = Pattern.compile(regexPattern);
        Matcher m = p.matcher(text);
        List<String> matchedStrings = new ArrayList<String>();

        while (m.find()) {
            matchedStrings.add(m.group().toLowerCase());
        }
        return matchedStrings;
    }

    public void processTextFile(String path, String regexPattern) {
        processedStrngs = sanitizeText(readText(path), regexPattern);
    }
}
