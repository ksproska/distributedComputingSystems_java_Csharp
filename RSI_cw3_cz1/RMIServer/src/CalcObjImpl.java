import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

/**
 * klasa z metodą realizującą obliczenia. Obiekty tego typu będą dostępnie zdalnie
 */
public class CalcObjImpl extends UnicastRemoteObject implements CalcObject {
    private static final long serialVersionUID = 101L;

    public CalcObjImpl() throws RemoteException {
        super();
    }

    public double calculate(double a, double b) throws RemoteException {
        double wynik = a + b;
        return wynik;
    }
}
