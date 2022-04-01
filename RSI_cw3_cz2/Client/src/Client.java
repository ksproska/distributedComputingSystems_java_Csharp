import remoteObjects.IAddObject;
import remoteObjects.IRunOperation;
import remoteObjects.RunOperationInputType;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.Arrays;

public class Client implements IClient {
    public Client() {
        // utworzenie/ustawienie systemowego menadżera bezpieczeństwa
        // (uwaga: nie jest to wymagane we wszystkich przypadkach – tu w kliencie jest zakomentowane –
        // w razie potrzeby zdalnego pobierania definicji klas trzeba zdjąć ten komentarz)

//        if (System.getSecurityManager() == null)
//            System.setSecurityManager(new SecurityManager());
    }
    @Override
    public <T extends Remote> T getRemoteObject(String serviceAddress, Class<T> objectInterface) {
        T rObject = null;
        try {
            // pobieranie referencji do zdalnego obiektu
            rObject = objectInterface.cast(java.rmi.Naming.lookup(serviceAddress));
            System.out.printf(
                    """
                    Successful lookup:\u001B[32m %s\u001B[0m =>\u001B[34m %s \u001B[0m
                    """, objectInterface.getName(), serviceAddress
            );
        } catch (Exception e) {
            if(e.getClass() == java.rmi.ConnectException.class) {
                System.out.println("Server is NOT RUNNING!");
                System.exit(-1);
            }
            System.out.println("Nie można pobrać referencji do " + serviceAddress);
            e.printStackTrace();
            System.exit(-1);
        }
        return rObject;
    }

//    <T extends Remote> Method getCalculateMethod(Class<T> objectClass, Class[] params) throws NoSuchMethodException {
//        return objectClass.getMethod("calculate", params);
//    }
//
//    <T extends Remote> void displayResultObject(T obj1, Object [] params) {
//        try {
//            Class[] paramsClasses = Arrays.stream(params).map(Object::getClass).toArray(Class[]::new);
//            Method calculateMethod = getCalculateMethod(obj1.getClass(), paramsClasses);
//            System.out.println(calculateMethod.invoke(obj1, params));
//        } catch (NoSuchMethodException | InvocationTargetException | IllegalAccessException e) {
//            e.printStackTrace();
//        }
//    }

    static private <T> void displayResultPattern(Object result, Class objectClass, Object ... params) {
        System.out.printf("Result for \u001B[32m%s\u001B[0m%s => %s\n",
                objectClass.getName(), Arrays.toString(params).replace('[', '(').replace(']', ')'), result);
    }

    public static void displayResult(IAddObject object, double var1, double var2) throws RemoteException {
        var result = object.calculate(var1, var2);
        displayResultPattern(result, IAddObject.class, var1, var2);
    }

    public static void displayResult(IRunOperation object, RunOperationInputType runOperationInputType) throws RemoteException {
        var result = object.calculate(runOperationInputType);
        displayResultPattern(result, IRunOperation.class, runOperationInputType);
    }


    public static void main(String[] args) throws RemoteException {
        var client = new Client();
        IAddObject addObject = client.getRemoteObject("//localhost/add", IAddObject.class);
        IRunOperation runOperationObject = client.getRemoteObject("//localhost/runOperation", IRunOperation.class);
        displayResult(addObject, 2, 3);
        displayResult(addObject, 4, 4);
        displayResult(runOperationObject, new RunOperationInputType("add", 3, 4));
        displayResult(runOperationObject, new RunOperationInputType("add", 3, 4));

//        client.displayResultObject(addObject, new Object[] {3.0, 4.0});
//        var met = client.getCalculateMethod(remoteObjects.IAddObject.class, new Class[] {double.class, double.class});
    }
}
