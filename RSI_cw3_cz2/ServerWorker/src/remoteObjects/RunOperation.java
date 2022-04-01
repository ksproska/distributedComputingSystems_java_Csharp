package remoteObjects;
import java.rmi.RemoteException;


public class RunOperation extends ARemoteObject implements IRunOperation {
    public RunOperation() throws RemoteException { super(); }

    @Override
    public RunOperationResultType calculate(RunOperationInputType runOperationInputType) throws RemoteException {
        displayRunningPattern(runOperationInputType);
        var operationName = runOperationInputType.getOperationName();
        var a = runOperationInputType.getA();
        var b = runOperationInputType.getB();

        double result = 0;
        if(operationName.equals("add")) {
            result = a + b;
        }
        if(operationName.equals("sub")) {
            result = a - b;
        }
        if(operationName.equals("mul")) {
            result = a * b;
        }
        if(operationName.equals("div")) {
            result = a / b;
        }
        return new RunOperationResultType(result);
    }
}