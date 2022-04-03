package remoteObjects;

import java.rmi.RemoteException;

public class ServerWorker extends ARemoteObject implements IServerWorker {
    public ServerWorker() throws RemoteException {
        super();
    }

    @Override
    public RunOperationResultType compute(RunOperationInputType runOperationInputType) throws RemoteException {
        return new RunOperation().calculate(runOperationInputType);
    }
}
