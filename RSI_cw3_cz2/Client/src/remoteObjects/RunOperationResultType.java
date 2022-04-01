package remoteObjects;


import java.io.Serializable;

public class RunOperationResultType implements Serializable {
    private static final long serialVersionUID = 101L;
    private double result;

    public RunOperationResultType(double result) {
        this.result = result;
    }

    public double getResult() {
        return result;
    }

    @Override
    public String toString() {
        return "RunOperationResultType{" +
                "result=" + result +
                '}';
    }
}
