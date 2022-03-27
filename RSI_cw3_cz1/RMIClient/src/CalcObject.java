import java.rmi.Remote;
import java.rmi.RemoteException;

/**
 * interfejs dla klasy obiektu zdalnego, identycznie jak dla serwera
 */
public interface CalcObject extends Remote {
    public double calculate(double a, double b) throws RemoteException;
}
