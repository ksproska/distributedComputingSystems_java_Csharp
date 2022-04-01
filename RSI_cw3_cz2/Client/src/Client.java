import com.sun.jdi.InterfaceType;

import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
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

    private <T> void displayResult(Object result, Class objectClass, Object ... params) {
        System.out.println("Result for " + objectClass.getName() + "" +
                Arrays.toString(params).replace('[', '(').replace(']', ')') +
                " => " + result);
    }

    void displayResultAddObject(IAddObject addObject, double var1, double var2) throws RemoteException {
        var obj1Result = addObject.calculate(var1, var2);
        displayResult(obj1Result, IAddObject.class, var1, var2);
    }

    public static void main(String[] args) throws RemoteException {
        var client = new Client();
        IAddObject obj1 = client.getRemoteObject("//localhost/add", IAddObject.class);
        client.displayResultAddObject(obj1, 2, 3);
        client.displayResultAddObject(obj1, 4, 4);

//        client.displayResultObject(obj1, new Object[] {3.0, 4.0});
//        var met = client.getCalculateMethod(IAddObject.class, new Class[] {double.class, double.class});
    }
}
