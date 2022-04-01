import java.rmi.Remote;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public abstract class ARemoteObject extends UnicastRemoteObject implements Remote {
    private static final long serialVersionUID = 101L;
    public ARemoteObject()  throws RemoteException {
        super();
    }

//    public static <T extends ARemoteObject> T invoke() throws RemoteException {
//        throw new IllegalStateException("Invoke not implemented");
//    }
}
