package remoteObjects;

import java.util.Arrays;

public class CalculateMax extends Task<Double> {
    private double[] values;

    public CalculateMax(double ... values) {
        this.values = values;
    }

    @Override
    public Double compute() {
        this.displayRunning(values);
        if (values.length == 0) return null;
        var result = values[0];
        for (double val :
                values) {
            if (val > result) {
                result = val;
            }
        }
        this.displayFinished(values);
        return result;
    }

    @Override
    public String toString() {
        return "CalculateMax{" +
                "values=" + Arrays.toString(values) +
                '}';
    }
}
