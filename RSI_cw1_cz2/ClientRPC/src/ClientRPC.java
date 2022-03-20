import org.apache.xmlrpc.XmlRpcClient;
import org.apache.xmlrpc.XmlRpcException;

import java.io.IOException;
import java.net.MalformedURLException;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import java.util.stream.Collectors;


public class ClientRPC {
    private static final String SERVER_NAME = "ServerRPC";
    // TODO: 10000 -> 10000 + numer komputera w laboratorium
    public static String URL(String host, int port) {
        return String.format("http://%s:%d", host, port);
    }
    public static final String ANSI_RESET = "\u001B[0m";
    public static final String ANSI_PURPLE = "\u001B[35m";
    public static final String ANSI_YELLOW = "\u001B[33m";
    public static final String ANSI_CYAN = "\u001B[36m";
//    public static final String ANSI_BLACK = "\u001B[30m";
//    public static final String ANSI_RED = "\u001B[31m";
//    public static final String ANSI_GREEN = "\u001B[32m";
//    public static final String ANSI_BLUE = "\u001B[34m";
//    public static final String ANSI_WHITE = "\u001B[37m";

    private final XmlRpcClient server;
    private final AC cb;

    public ClientRPC(String host, int port) throws MalformedURLException {
        server = new XmlRpcClient(URL(host, port));
        cb = new AC();
    }

    public ClientRPC(String url) throws MalformedURLException {
        server = new XmlRpcClient(url);
        cb = new AC();
    }

    private static String padRight(String s, int n) {
        return String.format("%-" + n + "s", s);
    }

    public static void printResult(String methodName, Object result, Object ... methodArgs) {
        var args = Arrays.stream(methodArgs).map(Object::toString).collect(Collectors.joining(", "));
        System.out.println(ANSI_CYAN + "SYNC  result" + ANSI_RESET + " for " + methodName + "(" + args + "): " + ANSI_PURPLE + result + ANSI_RESET);
    }

    public void printAsyncRun(String methodName, Object ... methodArgs) {
        var args = Arrays.stream(methodArgs).map(Object::toString).collect(Collectors.joining(", "));
        System.out.println(ANSI_PURPLE + "ASYNC method " + ANSI_RESET + methodName + "(" + args + ") is running.");
    }

    public void show() throws IOException, XmlRpcException {
        String currentMethodName = new Object() {}.getClass().getEnclosingMethod().getName();
        String result = (String) execute(currentMethodName);
        System.out.print(result);
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
        public void show() {}
        public Double distance(double latitude1, double longitude1, double latitude2, double longitude2) { return null; }
        public Integer[] myPrimes(int min, int max) { return null; }
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
                                + ": " + paramsClasses.length + "; of types: " + Arrays.toString(paramsClasses);
                    }
                    else {
                        try {
                            var paramsToPass = new Object[paramsClasses.length];
                            // TODO: the only acceptable types for now: Integer, int, String, Double, double
                            for (int i = 0; i < paramsClasses.length; i++) {
                                if (paramsClasses[i] == int.class || paramsClasses[i] == Integer.class) {
                                    paramsToPass[i] = Integer.parseInt(inputElems[i + 1]);
                                }
                                else if (paramsClasses[i] == double.class || paramsClasses[i] == Double.class) {
                                    paramsToPass[i] = Double.parseDouble(inputElems[i + 1]);
                                }
                                else {
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
        if (errorText != null) { System.out.println(ANSI_YELLOW + errorText + ANSI_RESET); }
    }

    private static final String IPV4_PATTERN = "^(([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\\.(?!$)|$)){4}$";
    private static final Pattern pattern = Pattern.compile(IPV4_PATTERN);

    public static boolean isValid(final String email) {
        Matcher matcher = pattern.matcher(email);
        return matcher.matches();
    }

    public static String scannerURL(String host, int port) {
        System.out.printf(
                """
                Do you wanna continue with default (%s)?
                \tyes        -> ENTER
                \tchoose IP  -> ip
                \tchoose DNS -> dns
                ->\s""",
                URL(host, port)
        );
        Scanner in = new Scanner(System.in);
        var continueStr = in.nextLine();
        var options = new ArrayList<String>();
        var defaultOption = "";
        var ipOption = "ip";
        var dnsOption = "dns";

        options.add(defaultOption);
        options.add(ipOption);
        options.add(dnsOption);

        while (!options.contains(continueStr)) {
            System.out.print(ANSI_YELLOW + "Incorrect input." + ANSI_RESET + "\n-> ");
            continueStr = in.nextLine();
        }
        if (Objects.equals(continueStr, dnsOption)) {
            System.out.print("Enter dns: ");
            host = in.nextLine();
            while (host.equals("")) {
                System.out.print(ANSI_YELLOW + "Incorrect input." + ANSI_RESET + "\nEnter dns: ");
                host = in.nextLine();
            }
        }
        else if (Objects.equals(continueStr, ipOption)) {
            System.out.print("Enter ip: ");
            host = in.nextLine();
            while (!isValid(host)) {
                System.out.print(ANSI_YELLOW + "Incorrect input." + ANSI_RESET + "\nEnter ip: ");
                host = in.nextLine();
            }
        }
        if(!continueStr.equals(defaultOption)) {
            System.out.print("Enter port number: ");
            try {
                port = Integer.parseInt(in.nextLine());
            }
            catch (NumberFormatException e) {
                port = -1;
            }
            while (port < 0) {
                System.out.print(ANSI_YELLOW + "Incorrect input." + ANSI_RESET + "\nEnter port number: ");
                try {
                    port = Integer.parseInt(in.nextLine());
                }
                catch (NumberFormatException ignored) {}
            }
        }
        if(continueStr.equals(defaultOption)) {
            System.out.println("Default settings chosen.");
        }
//        in.close();
        return URL(host, port);
    }

    public static void main(String[] args) {
        var host = "localhost";
        var port = 10000;
        var selectedURL = scannerURL(host, port);
        Scanner in = new Scanner(System.in);
        try {
            ClientRPC clientRPC = new ClientRPC(selectedURL);
            clientRPC.show();
            var endStr = "end";
            System.out.printf(
                    """
                    Connected to server
                    \tNAME: %s
                    \tURL:  %s
                    To end connection write: %s
                    ----------------------------------------------------------------------------------------------------------------------------------
                    Write command:
                    ->\s""",
                    URL(host, port),
                    SERVER_NAME,
                    endStr
            );

            String input = in.nextLine();

            while (!Objects.equals(input, endStr)) {
                clientRPC.runCommand(input);
                input = in.nextLine();
            }
        }
        catch (Exception exception) {
            System.err.printf("Server XML-RPC (NAME: %s; PORT: %s): %s\n", SERVER_NAME, port, exception);
        }
        System.out.println("Connection was terminated.");
    }
}
