/**
 * klasa główna serwera
 */
public class MyServer {
    public static void main(String[] args) {
        // pobieranie danych o adresie usługi (adresie zdalnego obiektu) z parametru wywołania programu
        if (args.length == 0) {
            System.out.println("You have to enter RMI object address in the form: //host_address/service_name");
            return;
        }

        // włączenie zezwoleń poprzez utworzenie/ustawienie systemowego menadżera bezpieczeństwa
        if (System.getSecurityManager() == null) {
            System.setSecurityManager(new SecurityManager());
        }

        try {
            // utworzenie instancji obiektu zdalnego
            CalcObjImpl implObiektu = new CalcObjImpl();
            // rejestracja obiektu-serwera w rejestrze (rmiregistry)
            java.rmi.Naming.rebind(args[0], implObiektu);

//            //tu czy osobny try/catch
//            CalcObjImpl2 implObiektu2 = new CalcObjImpl2();
//            java.rmi.Naming.rebind(args[0], implObiektu2);

            System.out.println(
                """
                Server is registered now :-)
                Press Ctrl+C to stop...
                """
            );
        } catch (Exception e) {
            System.out.println("SERVER CAN'T BE REGISTERED!");
            e.printStackTrace();
            return;
        }
    }
}
