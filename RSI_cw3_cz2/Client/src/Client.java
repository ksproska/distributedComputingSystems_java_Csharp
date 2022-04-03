import remoteObjects.*;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.Arrays;


public class Client implements IClient {
    public Client() {
        // utworzenie/ustawienie systemowego menadżera bezpieczeństwa
        // (uwaga: nie jest to wymagane we wszystkich przypadkach – tu w kliencie jest zakomentowane –
        // w razie potrzeby zdalnego pobierania definicji klas trzeba zdjąć ten komentarz)

//        if (System.getSecurityManager() == null)
//            System.setSecurityManager(new SecurityManager());
    }
    @Override
    public <T extends Remote> T getRemoteObject(String serviceAddress, Class<T> objectInterface) {
        T rObject = null;
        try {
            // pobieranie referencji do zdalnego obiektu
            rObject = objectInterface.cast(java.rmi.Naming.lookup(serviceAddress));
            System.out.printf(
                    """
                    Successful lookup:\u001B[32m %s\u001B[0m =>\u001B[34m %s \u001B[0m
                    """, objectInterface.getName(), serviceAddress
            );
        } catch (Exception e) {
            if(e.getClass() == java.rmi.ConnectException.class) {
                System.out.println("Server is NOT RUNNING!");
                System.exit(-1);
            }
            System.out.printf(
                    """
                    ERROR FOR:\u001B[32m %s\u001B[0m =>\u001B[34m %s \u001B[0m
                    """, objectInterface.getName(), serviceAddress
            );
            e.printStackTrace();
            System.exit(-1);
        }
        return rObject;
    }

    static private <T> void displayResultPattern(Object result, Class objectClass, Object ... params) {
        System.out.printf("Result for \u001B[32m%s\u001B[0m%s => %s\n",
                objectClass.getName(), Arrays.toString(params).replace('[', '(').replace(']', ')'), result);
    }

    public static void main(String[] args) throws RemoteException {
        var client = new Client();
        IServerWorker serverWorker = client.getRemoteObject("//localhost/sw1", IServerWorker.class);
        var calc = new CalculatePi();
        var result = serverWorker.compute(calc);
        System.out.println(result);
    }
}
