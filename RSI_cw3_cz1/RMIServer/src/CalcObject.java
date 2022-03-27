import java.rmi.Remote;
import java.rmi.RemoteException;

/**
 * interfejs dla klasy obiektu zdalnego (który będzie dostępny zdalnie dla klienta
 */
public interface CalcObject extends Remote {
    public double calculate(double a, double b) throws RemoteException;
}
