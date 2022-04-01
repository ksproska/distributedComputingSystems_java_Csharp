package remoteObjects;
import java.io.Serializable;


public class RunOperationInputType implements Serializable {
    private static final long serialVersionUID = 101L;

    private String operationName;
    private double a;
    private double b;

    public RunOperationInputType(String operationName, double a, double b) {
        this.operationName = operationName;
        this.a = a;
        this.b = b;
    }

    public String getOperationName() {
        return operationName;
    }

    public double getA() {
        return a;
    }

    public double getB() {
        return b;
    }

    @Override
    public String toString() {
        return "RunOperationInputType{" +
                "operationName='" + operationName + '\'' +
                ", a=" + a +
                ", b=" + b +
                '}';
    }
}
