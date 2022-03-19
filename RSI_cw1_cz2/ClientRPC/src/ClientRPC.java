import org.apache.xmlrpc.XmlRpcClient;
import org.apache.xmlrpc.XmlRpcException;

import java.io.IOException;
import java.lang.invoke.VarHandle;
import java.net.MalformedURLException;
import java.util.Arrays;
import java.util.Vector;

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

    public static String padRight(String s, int n) {
        return String.format("%-" + n + "s", s);
    }

    private void printResult(String methodName, Object result, Object ... methodArgs) {
        String args = "";
        for (var arg : methodArgs) {
            args += arg + ", ";
        }
        if(args.length() > 2) {
            args = args.substring(0, args.length() - 2);
        }
        System.out.println(padRight(methodName + "(" + args + "):", 30) + result);
    }

    public void show() throws IOException, XmlRpcException {
        var currentMethod = new Object() {}.getClass().getEnclosingMethod();
        var currentMethodName = currentMethod.getName();
        var executableMethod = String.format("%s.%s", SERVER_NAME, currentMethodName);

        String result = (String) server.execute(executableMethod, new Vector<>());

        System.out.println(result);
    }

    public void max(int val1, int val2) throws IOException, XmlRpcException {
        var currentMethod = new Object() {}.getClass().getEnclosingMethod();
        var currentMethodName = currentMethod.getName();
        var executableMethod = String.format("%s.%s", SERVER_NAME, currentMethodName);

        Vector<Integer> vector = new Vector<>();
        vector.addElement(val1);
        vector.addElement(val2);
        Integer result = (Integer) server.execute(executableMethod, vector);

        printResult(currentMethodName, result, val1, val2);
    }

    public void charAt(String text, int charInx) throws IOException, XmlRpcException {
        String currentMethodName = new Object() {}.getClass().getEnclosingMethod().getName();
        String executableMethod = String.format("%s.%s", SERVER_NAME, currentMethodName);

        Vector<Object> vector = new Vector<>();
        vector.addElement(text);
        vector.addElement(charInx);
        String result = (String) server.execute(executableMethod, vector);

        printResult(currentMethodName, result, text, charInx);
    }

    public void execAsy(int value) {
        String currentMethodName = new Object() {}.getClass().getEnclosingMethod().getName();
        String executableMethod = String.format("%s.%s", SERVER_NAME, currentMethodName);

        Vector<Integer> params = new Vector<>();
        params.addElement(value);
        server.executeAsync(executableMethod, params, cb);
        System.out.println("Wywolano asynchronicznie");
    }

    public static void main(String[] args) {
        try {
            ClientRPC clientRPC = new ClientRPC();
            clientRPC.show();
            clientRPC.max(2, 5);
            clientRPC.charAt("Kamila Sproska", 3);
//            clientRPC.execAsy(55000);
//            clientRPC.execAsy(3000);
        }
        catch (Exception exception) {
            System.err.println("Client XML-RPC: " + exception);
        }
    }
}
