package remoteObjects;

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface IRunOperation extends Remote {
    double calculate(String operationName, double a, double b) throws RemoteException;
}
