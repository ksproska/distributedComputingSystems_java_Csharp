import java.util.Scanner;
import java.util.Vector;

public class Main {
    public static void main(String[] args) {
        // run: java -jar RSI_01_2.jar
        Scanner in = new Scanner(System.in);
        System.out.print("Enter your name: ");
        String name = in.nextLine();
        System.out.printf("My name is: %s%n", name);
        in.close();

        Vector<Integer> params = new Vector<>();
        params.addElement(13);
        params.addElement(21);
        params.addElement(21);
        System.out.println(params);
        System.out.println(params.size());
        System.out.println(params.capacity());
    }
}

