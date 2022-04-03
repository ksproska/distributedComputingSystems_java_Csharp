package remoteObjects;

import java.rmi.RemoteException;

public class ServerWorker extends ARemoteObject implements IServerWorker {
    public ServerWorker() throws RemoteException {
        super();
    }

    @Override
    public <T> T compute(ITask<T> inputITask) throws RemoteException {
        return inputITask.compute();
    }
}
