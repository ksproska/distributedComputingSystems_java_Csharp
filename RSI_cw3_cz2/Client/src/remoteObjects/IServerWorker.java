package remoteObjects;
import java.rmi.Remote;
import java.rmi.RemoteException;


public interface IServerWorker extends Remote {
    RunOperationResultType compute(RunOperationInputType runOperationInputType) throws RemoteException;
    <T> T compute(ITask<T> inputITask) throws RemoteException;
}
