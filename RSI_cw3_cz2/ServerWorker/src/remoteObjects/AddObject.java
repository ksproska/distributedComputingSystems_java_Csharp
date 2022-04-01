package remoteObjects;
import java.rmi.RemoteException;


public class AddObject extends ARemoteObject implements IAddObject {
    public AddObject() throws RemoteException { super(); }

    @Override
    public double calculate(double a, double b) throws RemoteException {
        displayRunningPattern(a, b);
        return a + b;
    }
}
