/**
 * klasa główna klienta
 */
public class MyClient {
    public static void main(String[] args) {
        // deklaracja odpowiednich zmiennych, w tym zmiennej/referencji obiektu zdalnego (interfejsu)
        double wynik;
        CalcObject zObiekt;
        CalcObject2 zObiekt2;
        ResultType wynik2;
        InputType inObj;

        // pobieranie danych o adresie usługi (adresu zdalnego obiektu) z parametru wywołania programu
//        if (args.length == 0) {
//            System.out.println("You have to enter RMI object address in the form: // host_address/service_name ");
//            return;
//        }
        if (args.length < 2) {
            System.out.println("You have to enter RMI object address in the form: // host_address/service_name ");
            return;
        }

        String adres = args[0];
        String adres2 = args[1];

        // utworzenie/ustawienie systemowego menadżera bezpieczeństwa
        // (uwaga: nie jest to wymagane we wszystkich przypadkach – tu w kliencie jest zakomentowane –
        // w razie potrzeby zdalnego pobierania definicji klas trzeba zdjąć ten komentarz)

//        if (System.getSecurityManager() == null)
//            System.setSecurityManager(new SecurityManager());

        try {
            // pobieranie referencji do zdalnego obiektu
            zObiekt = (CalcObject) java.rmi.Naming.lookup(adres);
        } catch (Exception e) {
            System.out.println("Nie można pobrać referencji do "+adres);
            e.printStackTrace();
            return;
        }
        System.out.println("Referencja do " + adres + " jest pobrana.");

        try {
            // pobieranie referencji do zdalnego obiektu
            zObiekt2 = (CalcObject2) java.rmi.Naming.lookup(adres2);
        } catch (Exception e) {
            System.out.println("Nie można pobrać referencji do "+adres2);
            e.printStackTrace();
            return;
        }
        System.out.println("Referencja do " + adres2 + " jest pobrana.");

        try {
            // wywołanie usługi (metody zdalnego obiektu) i wyświetlenie odpowiedzi
            wynik = zObiekt.calculate(1.1, 2.2);
        } catch (Exception e) {
            System.out.println("Blad zdalnego wywolania.");
            e.printStackTrace();
            return;
        }
        System.out.println("Wynik = "+ wynik);

        try {
            // obiekt-zadania - parametr dla metody zdalnej
            inObj = new InputType();
            //  składowe obiektu-zadania
            inObj.x1 = 10.5;
            inObj.x2 = 3.2;
            inObj.operation="add"; //lub "sub"
            wynik2 = zObiekt2.calculate(inObj);
        } catch (Exception e) {
            System.out.println("Blad zdalnego wywolania.");
            e.printStackTrace();
            return;
        }
        System.out.println("Wynik2: " + wynik2.result_description + " = " + wynik2.result);
    }
}
