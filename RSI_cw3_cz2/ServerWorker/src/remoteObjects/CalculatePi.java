package remoteObjects;

public class CalculatePi extends Task<Double> {
    @Override
    public Double compute() {
        this.displayRunning();
        var result = 3.14;
        this.displayFinished();
        return result;
    }
}
