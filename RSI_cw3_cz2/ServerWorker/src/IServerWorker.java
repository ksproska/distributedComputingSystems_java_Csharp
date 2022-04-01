import java.rmi.Remote;
import java.rmi.RemoteException;

public interface IServerWorker extends Remote {
    double calculate(IAddObject remoteObject, double val1, double val2) throws RemoteException;
    <T extends ARemoteObject> void registerObject(String serviceAddress, Class<T> objectClass);
}
