package remoteObjects;

import java.util.Arrays;

public class CalculateMax extends Task<Double> {
    private double[] values;

    public CalculateMax(double ... values) {
        this.values = values;
    }

    @Override
    public Double compute() { return null; }

    @Override
    public String toString() {
        return "CalculateMax{" +
                "values=" + Arrays.toString(values) +
                '}';
    }
}
