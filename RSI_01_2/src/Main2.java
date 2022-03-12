import java.util.ArrayList;
import java.util.Scanner;
import java.util.Vector;

public class Main2 {
    public static void main(String[] args) {
        // run: java -jar RSI_01_2.jar
        MyData.info();
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
        System.out.println(params.get(0) + params.get(1));

        ArrayList<Integer> list = new ArrayList<>();
        list.add(13);
        list.add(21);
        list.add(21);
        System.out.println(list);
        System.out.println(list.size());
        System.out.println(list.get(0) + list.get(1));
    }
}

