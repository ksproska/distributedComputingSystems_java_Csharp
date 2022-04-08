package remoteObjects;


import java.math.BigDecimal;

public class CalculatePi extends Task<BigDecimal> {
    private int precision;

    public CalculatePi(int precision) {
        this.precision = precision;
    }

    @Override
    public BigDecimal compute() {
        this.displayRunning(precision);
        var result = PiCalc.compute(precision);
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
