import remoteObjects.ARemoteObject;
import remoteObjects.ServerWorker;

import java.net.MalformedURLException;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;


public class ObjectRegistrator implements IObjectRegistrator {
    public static final String hostname = "localhost";
    public ObjectRegistrator() {
        System.setProperty("java.rmi.server.hostname", hostname);
        System.setProperty("java.security.policy", System.getProperty("user.dir") + "\\srv.policy");
        // włączenie zezwoleń poprzez utworzenie/ustawienie systemowego menadżera bezpieczeństwa
//        if (System.getSecurityManager() == null) {
//            System.setSecurityManager(new SecurityManager());
//        }
        // kod utworzenia rejestru dla serwera - realizacja programowa, jesli rejestr i serwer odpalane sa na tym samym komputerze
        // TODO: skomentowac, jesli reczna konfiguracja i uruchomienie
        try {
            Registry reg = LocateRegistry.createRegistry(1099);
        } catch (RemoteException e1) {
            if(e1.getClass() == java.rmi.server.ExportException.class) {
                System.out.println("\nThis program is ALREADY RUNNING somewhere!");
                System.exit(-1);
            }
            e1.printStackTrace();
        }
    }

    @Override
    public <T extends ARemoteObject> void registerObject(String serviceAddress, Class<T> objectClass) {
        T remoteObject;
        try {
            remoteObject = objectClass.newInstance();
        } catch (InstantiationException | IllegalAccessException e) {
            throw new IllegalStateException("Invoking object for class " + objectClass.getName() + " didn't work.");
        }
        try {
            java.rmi.Naming.rebind(serviceAddress, remoteObject);
            System.out.printf(
                    """
                    \s\tSuccessful registration:\u001B[32m %s\u001B[0m =>\u001B[34m %s \u001B[0m
                    """, remoteObject.getClass().getName(), serviceAddress
            );
        } catch (RemoteException | MalformedURLException | java.security.AccessControlException e) {
            e.printStackTrace();
            System.exit(-1);
            throw new IllegalStateException(
                    "Object " + remoteObject.getClass().getName() +
                            " for address " + serviceAddress + " couldn't be registered!");
        }
    }

    public static void main(String[] args) {
//        MyData.info();
        var objectRegistrator = new ObjectRegistrator();
        System.out.println("\sServer started running...");
        objectRegistrator.registerObject("//" + hostname + "/sw1", ServerWorker.class);
        objectRegistrator.registerObject("//" + hostname + "/sw2", ServerWorker.class);
        objectRegistrator.registerObject("//" + hostname + "/sw3", ServerWorker.class);
        System.out.println("\sAll set and running.\n");
    }
}
