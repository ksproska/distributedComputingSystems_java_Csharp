import org.apache.xmlrpc.XmlRpcClient;
import org.apache.xmlrpc.XmlRpcException;

import java.io.IOException;
import java.lang.reflect.Method;
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
        System.out.println("SYNC result for " + methodName + "(" + args + "):\n\t" + result);
    }

    public void printAsyncRun(String methodName, Object ... methodArgs) {
        var args = Arrays.stream(methodArgs).map(Object::toString).collect(Collectors.joining(", "));
        System.out.println("ASYNC method " + methodName + "(" + args + ") is running.");
    }

    public void show() throws IOException, XmlRpcException {
        String currentMethodName = new Object() {}.getClass().getEnclosingMethod().getName();
        String result = (String) execute(currentMethodName);
        System.out.println(result);
    }

    public Object execute(String methodName, Object ... args) throws IOException, XmlRpcException {
        Vector<Object> vector = new Vector<>();
        for (Object arg : args) {
            vector.addElement(arg);
        }
        var executableMethod = String.format("%s.%s", SERVER_NAME, methodName);
        return server.execute(executableMethod, vector);
    }

    public void executeAsync(String methodName, Object ... args) {
        Vector<Object> vector = new Vector<>();
        for (Object arg : args) {
            vector.addElement(arg);
        }
        var executableMethod = String.format("%s.%s", SERVER_NAME, methodName);
        server.executeAsync(executableMethod, vector, cb);
    }

    public static class ExecutableMethods {
        // this class methods are necessary for evaluating correctness of names and parameters in commands
        public Integer max(int val1, int val2) { return null; }
        public String charAt(String text, int charInx) { return null; }
        public Integer[] setTimer(int everyXSec, int repeat) { return null; }
    }

    public void runCommand(String input) throws IOException, XmlRpcException {
        String asyncFlag = "-a";
        var methods = ExecutableMethods.class.getMethods();

        boolean isAsync = input.contains(asyncFlag);
        input = input.replace(" " + asyncFlag, "");
        var inputElems = input.split(" ");
        // TODO: problem with input string in quotation marks, e.g. charAt "txt example" 6
        var methodName = inputElems[0];
        String errorText = "No command matches input.";

        for (var method : methods) {
            if (method.getName().equals(methodName)) {
                var paramsClasses = method.getParameterTypes();
                    if (paramsClasses.length != inputElems.length - 1) {
                        errorText = "Expected number of parameters for method " + methodName.toUpperCase()
                                + ": " + paramsClasses.length;
                    }
                    else {
                        try {
                            var paramsToPass = new Object[paramsClasses.length];
                            // TODO: the only acceptable types for now: Integer, int, String
                            for (int i = 0; i < paramsClasses.length; i++) {
                                if (paramsClasses[i] == int.class || paramsClasses[i] == Integer.class) {
                                    paramsToPass[i] = Integer.parseInt(inputElems[i + 1]);
                                } else {
                                    paramsToPass[i] = inputElems[i + 1];
                                }
                            }
                            if (isAsync) {
                                executeAsync(methodName, paramsToPass);
                                printAsyncRun(methodName, paramsToPass);
                            } else {
                                var result = execute(methodName, paramsToPass);
                                printResult(methodName, result, paramsToPass);
//                                System.out.println(result);
                            }
                            errorText = null;
                        }
                        catch (NumberFormatException exception) {
                            errorText = "Expected parameter types for method " + methodName.toUpperCase() + ": "
                                    + Arrays.toString(paramsClasses);
                        }
                    }
            }
        }
        if (errorText != null) { System.out.println(errorText); }
    }

    public static void main(String[] args) {
        try {
            ClientRPC clientRPC = new ClientRPC();
            clientRPC.show();
            System.out.print("Write command:\n-> ");

            Scanner in = new Scanner(System.in);
            String input = in.nextLine();

            while (!Objects.equals(input, "end")) {
                clientRPC.runCommand(input);
                input = in.nextLine();
            }
        }
        catch (Exception exception) {
            System.err.println("Client XML-RPC: " + exception);
        }
    }
}
