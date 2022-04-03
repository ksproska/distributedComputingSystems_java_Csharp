package remoteObjects;


public class CalculatePi extends Task<PiReturnType> {
    private int precision;

    public CalculatePi(int precision) {
        this.precision = precision;
    }

    @Override
    public PiReturnType compute() {
        this.displayRunning(precision);
        var result = new PiReturnType(3.14);
        this.displayFinished(precision);
        return result;
    }

    @Override
    public String toString() {
        return "CalculatePi{" +
                "precision=" + precision +
                '}';
    }
}
