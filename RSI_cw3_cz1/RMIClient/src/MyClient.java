/**
 * klasa główna klienta
 */
public class MyClient {
    public static void main(String[] args) {
        // deklaracja odpowiednich zmiennych, w tym zmiennej/referencji obiektu zdalnego (interfejsu)
        double wynik;
        CalcObject zObiekt;

        // pobieranie danych o adresie usługi (adresu zdalnego obiektu) z parametru wywołania programu
        if (args.length == 0) {
            System.out.println("You have to enter RMI object address in the form: // host_address/service_name ");
            return;
        }
        String adress = args[0];

        // utworzenie/ustawienie systemowego menadżera bezpieczeństwa
        // (uwaga: nie jest to wymagane we wszystkich przypadkach – tu w kliencie jest zakomentowane –
        // w razie potrzeby zdalnego pobierania definicji klas trzeba zdjąć ten komentarz)

//        if (System.getSecurityManager() == null)
//            System.setSecurityManager(new SecurityManager());

        try {
            // pobieranie referencji do zdalnego obiektu
            zObiekt = (CalcObject) java.rmi.Naming.lookup(adress);
        } catch (Exception e) {
            System.out.println("Nie można pobrać referencji do "+adress);
            e.printStackTrace();
            return;
        }
        System.out.println("Referencja do " + adress + " jest pobrana.");

        try {
            // wywołanie usługi (metody zdalnego obiektu) i wyświetlenie odpowiedzi
            wynik = zObiekt.calculate(1.1, 2.2);
        } catch (Exception e) {
            System.out.println("Blad zdalnego wywolania.");
            e.printStackTrace();
            return;
        }
        System.out.println("Wynik = "+ wynik);
    }
}
