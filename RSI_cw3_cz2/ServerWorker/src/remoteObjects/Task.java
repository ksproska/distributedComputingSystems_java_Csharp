package remoteObjects;


public class Task<T> implements ITask<T> {
    private static final long serialVersionUID = 102L;
    @Override
    public T compute() { return null; }

    protected void displayRunning(Object ... params) {
        System.out.printf("Calculating \u001B[32m%s\u001B[0m...\n", this);
    }

    protected void displayFinished(Object ... params) {
//        System.out.printf("Finished calculating \u001B[32m%s\u001B[0m\n", this);
    }
}
