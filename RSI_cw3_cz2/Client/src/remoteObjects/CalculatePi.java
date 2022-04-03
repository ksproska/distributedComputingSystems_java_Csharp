package remoteObjects;


public class CalculatePi extends Task<PiReturnType> {
    private int precision;

    public CalculatePi(int precision) {
        this.precision = precision;
    }

    @Override
    public PiReturnType compute() { return null; }

    @Override
    public String toString() {
        return "CalculatePi{" +
                "precision=" + precision +
                '}';
    }
}