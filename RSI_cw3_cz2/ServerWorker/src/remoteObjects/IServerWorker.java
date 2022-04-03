package remoteObjects;

import remoteObjects.RunOperation;
import remoteObjects.RunOperationInputType;
import remoteObjects.RunOperationResultType;

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface IServerWorker extends Remote {
    <T extends RunOperation> RunOperationResultType compute(RunOperationInputType runOperationInputType) throws RemoteException;
}
