package remoteObjects;


public class PiReturnType extends ReturnType {
    private final double pi;

    public PiReturnType(double pi) {
        this.pi = pi;
    }

    @Override
    public String toString() {
        return "PiReturnType{" +
                "pi=" + pi +
                '}';
    }
}
