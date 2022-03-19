import org.apache.xmlrpc.WebServer;

import java.util.Arrays;

public class ServerRPC {
    private static final String SERVER_NAME = "ServerRPC";
    // TODO: 10000 -> 10000 + numer komputera w laboratorium
    private static final int PORT = 10000;

    /**
     * Serwer  zawiera  usługę/procedurę  show,  która  podaje  informacje  o  dostępnych
     * procedurach – wyświetla ich listę z opisem (nazwa procedury, parametry, krótki opis)
     */
    public String show() {
        return """
                Available methods for server:
                1. max int int        - returns maximum value
                2. charAt String int  - returns char at index of given text
                
                To run async method add flag: -a
                """;
    }

    public Integer max(int val1, int val2) {
        return Math.max(val1, val2);
    }

    public String charAt(String text, int charInx) {
        if(text.length() <= charInx) {
            return null;
        }
        return text.charAt(charInx) + "";
    }

    /**
     * Procedura asynchroniczna, będzie teoretycznie długo coś wykonywać,
     * co zasymulowane będzie wstrzymaniem wykonywania na okres x milisekund
     *
     * @param x parametr podawany w wywołaniu procedury) metodą Thread.sleep(x)
     * @return
     */
    public int execAsy(int x) {
        System.out.println("... wywołano asy - odliczam");
        try {
            Thread.sleep(x);
        } catch(InterruptedException ex) {
            ex.printStackTrace();
            Thread.currentThread().interrupt();
        }
        System.out.println("... asy - koniec odliczania");
        return (123);
    }

    //------------------------------------------------------------------------------------------------------------------

    public static void startServer() {
        WebServer server = new WebServer(PORT);
        server.addHandler(SERVER_NAME, new ServerRPC());
        server.start();
    }

    public static void main(String[] args) {
        try {
            System.out.println("""
                    ________________________________
                    Server XML-RPC is starting...
                    """);
            startServer();
            System.out.printf("""
                    Server has started successfully.
                    PORT:      %s
                    to finish: ctrl+c
                    ________________________________
                    """, PORT);
        }
        catch (Exception exception) {
            System.err.println("Server XML-RPC: " + exception);
        }
    }
}
