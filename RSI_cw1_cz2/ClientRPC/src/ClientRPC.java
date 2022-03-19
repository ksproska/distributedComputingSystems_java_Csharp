import org.apache.xmlrpc.XmlRpcClient;
import org.apache.xmlrpc.XmlRpcException;

import java.io.IOException;
import java.lang.invoke.VarHandle;
import java.net.MalformedURLException;
import java.util.Arrays;
import java.util.Objects;
import java.util.Scanner;
import java.util.Vector;
import java.util.stream.Collectors;

public class ClientRPC {
    private static final String SERVER_NAME = "ServerRPC";
    // TODO: 10000 -> 10000 + numer komputera w laboratorium
    private static final int PORT = 10000;
    private static final String hamachiIP = "", localhost = "localhost";
    private static final String URL = String.format(
            "http://%s:%d",
//            hamachiIP,
            localhost,
            PORT
    );

    private final XmlRpcClient server;
    private final AC cb;

    public ClientRPC() throws MalformedURLException {
        server = new XmlRpcClient(URL);
        cb = new AC();
    }

    private static String padRight(String s, int n) {
        return String.format("%-" + n + "s", s);
    }

    public static void printResult(String methodName, Object result, Object ... methodArgs) {
        var args = Arrays.stream(methodArgs).map(Object::toString).collect(Collectors.joining(", "));
        System.out.println(methodName + "(" + args + "): " + result);
    }

    private void printAsyncRun(String methodName, Object ... methodArgs) {
        var args = Arrays.stream(methodArgs).map(Object::toString).collect(Collectors.joining(", "));
        System.out.println("ASYNC method: " + methodName + "(" + args + ") is running.");
    }

    public void show() throws IOException, XmlRpcException {
        String currentMethodName = new Object() {}.getClass().getEnclosingMethod().getName();
        String result = (String) execute(currentMethodName);
        System.out.println(result);
    }

    private Object execute(String methodName, Object ... args) throws IOException, XmlRpcException {
        Vector<Object> vector = new Vector<>();
        for (Object arg : args) {
            vector.addElement(arg);
        }
        var executableMethod = String.format("%s.%s", SERVER_NAME, methodName);
        return server.execute(executableMethod, vector);
    }

    private void executeAsync(String methodName, Object ... args) {
        Vector<Object> vector = new Vector<>();
        for (Object arg : args) {
            vector.addElement(arg);
        }
        var executableMethod = String.format("%s.%s", SERVER_NAME, methodName);
        server.executeAsync(executableMethod, vector, cb);
    }

    public void max(int val1, int val2) throws IOException, XmlRpcException {
        String currentMethodName = new Object() {}.getClass().getEnclosingMethod().getName();
        Integer result = (Integer) execute(currentMethodName, val1, val2);
        printResult(currentMethodName, result, val1, val2);
    }

    public void charAt(String text, int charInx) throws IOException, XmlRpcException {
        String currentMethodName = new Object() {}.getClass().getEnclosingMethod().getName();
        String result = (String) execute(currentMethodName, text, charInx);
        printResult(currentMethodName, result, text, charInx);
    }

    public void execAsy(int value) {
        String currentMethodName = new Object() {}.getClass().getEnclosingMethod().getName();
        executeAsync(currentMethodName, value);
        printAsyncRun(currentMethodName, value);
    }

    public static void main(String[] args) {
        String asyncFlag = "-a";
        try {
            ClientRPC clientRPC = new ClientRPC();
            clientRPC.show();
            System.out.print("Write command:\n-> ");

            Scanner in = new Scanner(System.in);
            String input = in.nextLine();
            var methods = ClientRPC.class.getMethods();

            while (!Objects.equals(input, "end")) {
                boolean isAsync = input.contains(asyncFlag);
                input = input.replace(" " + asyncFlag, "");
                var inputElems = input.split(" ");
                var methodName = inputElems[0];
                String errorText = "No command matches input.";
                for (var method : methods) {
                    if (method.getName().equals(methodName)) {
                        var paramsClasses = method.getParameterTypes();
                        try {
                            if (paramsClasses.length == inputElems.length - 1) {
                                var params = new Object[paramsClasses.length];
                                for (int i = 0; i < paramsClasses.length; i++) {
//                                System.out.println(inputElems[i + 1].getClass());
                                    if (paramsClasses[i] == int.class || paramsClasses[i] == Integer.class) {
                                        params[i] = Integer.parseInt(inputElems[i + 1]);
                                    } else {
                                        params[i] = inputElems[i + 1];
                                    }
                                }
                                if(isAsync) {
                                    clientRPC.executeAsync(methodName, params);
                                    errorText = null;
                                }
                                else {
                                    var result = clientRPC.execute(methodName, params);
                                    errorText = null;
                                    printResult(methodName, result, params);
                                }
                            }
                            else {
                                errorText = "Expected number of parameters for method " + methodName.toUpperCase() + ": " + paramsClasses.length;
                            }
                        }
                        catch (NumberFormatException exception) {
                            errorText = "Expected parameter types for method " + methodName.toUpperCase() + ": " + Arrays.toString(paramsClasses);
                        }
                    }
                }
                if(errorText != null) {
                    System.out.println(errorText);
                }
//                System.out.print("-> ");
                input = in.nextLine();
            }
        }
        catch (Exception exception) {
            System.err.println("Client XML-RPC: " + exception);
        }
    }
}
