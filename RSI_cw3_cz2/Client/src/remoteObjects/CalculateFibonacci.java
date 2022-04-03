package remoteObjects;

public class CalculateFibonacci extends Task<String> {
    private int n;

    public CalculateFibonacci(int n) {
        this.n = n;
    }

    @Override
    public String compute() {
        int firstTerm = 0, secondTerm = 1;
        String result = "";
        for (int i = 1; i <= n; ++i) {
            result += firstTerm + ", ";

            // compute the next term
            int nextTerm = firstTerm + secondTerm;
            firstTerm = secondTerm;
            secondTerm = nextTerm;
        }
        return result;
    }

    @Override
    public String toString() {
        return "CalculateFibonacci{" +
                "n=" + n +
                '}';
    }
}
