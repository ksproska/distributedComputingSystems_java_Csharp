package remoteObjects;
import java.rmi.Remote;
import java.rmi.RemoteException;


public interface IAddObject extends Remote {
    double calculate(double a, double b) throws RemoteException;
}
