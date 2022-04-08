import remoteObjects.*;

import java.rmi.Remote;
import java.rmi.RemoteException;


public class Client implements IClient {
    public static final String hostname = "localhost";
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

    static private <T> void displayResultPattern(Object result, Object obj) {
        System.out.printf("Result for \u001B[32m%s\u001B[0m => %s\n", obj, result);
    }

    public static void main(String[] args) throws RemoteException {
        var client = new Client();
        IServerWorker sw1 = client.getRemoteObject("//" + hostname + "/sw1", IServerWorker.class);
        IServerWorker sw2 = client.getRemoteObject("//" + hostname + "/sw2", IServerWorker.class);
        IServerWorker sw3 = client.getRemoteObject("//" + hostname + "/sw3", IServerWorker.class);

        var task1 = new CalculatePi(5);
        var task2 = new CalculatePi(100);
        var task3 = new CalculateMax(0.2, 3904, 22.33, 30000);

        var workers = new IServerWorker[]{sw1, sw2, sw3};
        var tasks = new Task[]{task1, task2, task3};

        for (int i = 0; i < workers.length; i++) {
            var result = workers[i].compute(tasks[i]);
            Client.displayResultPattern(result, tasks[i]);
        }
    }
}
