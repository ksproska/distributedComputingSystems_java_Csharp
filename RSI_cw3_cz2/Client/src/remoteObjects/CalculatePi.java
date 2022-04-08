package remoteObjects;
import java.math.BigDecimal;


public class CalculatePi extends Task<BigDecimal> {
    private int precision;

    public CalculatePi(int precision) {
        this.precision = precision;
    }

    @Override
    public BigDecimal compute() { return null; }

    @Override
    public String toString() {
        return "CalculatePi{" +
                "precision=" + precision +
                '}';
    }
}