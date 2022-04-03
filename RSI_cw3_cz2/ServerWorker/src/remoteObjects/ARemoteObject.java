package remoteObjects;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.Arrays;

public abstract class ARemoteObject extends UnicastRemoteObject implements Remote {
    private static final long serialVersionUID = 101L;
    public ARemoteObject() throws RemoteException { super(); }

    protected void displayRunningPattern(Object ... params) {
        System.out.printf("Calculating \u001B[32m%s\u001B[0m%s\n",
                this.getClass().getName(),
                Arrays.toString(params).replace('[', '(').replace(']', ')'));
    }
}
