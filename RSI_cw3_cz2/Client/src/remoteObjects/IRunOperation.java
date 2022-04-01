package remoteObjects;
import java.rmi.Remote;
import java.rmi.RemoteException;


public interface IRunOperation extends Remote {
    RunOperationResultType calculate(RunOperationInputType runOperationInputType) throws RemoteException;
}
