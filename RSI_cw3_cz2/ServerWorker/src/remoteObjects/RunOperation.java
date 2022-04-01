package remoteObjects;

import java.rmi.RemoteException;

public class RunOperation extends ARemoteObject implements IRunOperation {
    public RunOperation() throws RemoteException { super(); }

    @Override
    public double calculate(String operationName, double a, double b) throws RemoteException {
        if(operationName.equals("add")) {
            return a + b;
        }
        if(operationName.equals("sub")) {
            return a - b;
        }
        if(operationName.equals("mul")) {
            return a * b;
        }
        if(operationName.equals("div")) {
            return a / b;
        }
        return 0;
    }
}