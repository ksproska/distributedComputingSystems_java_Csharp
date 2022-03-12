import org.apache.xmlrpc.WebServer;

public class Main {
    public static void main(String[] args) {
        try {
            System.out.println("Startuje serwer XML-RPC...");
            int port = 10000; //10000+nr komputera w laboratorium
            WebServer server = new WebServer(port);
            server.addHandler("MojSerwer", new serwerRPC());
            server.start();
            System.out.println("Serwer wystartowal pomyslnie.");
            System.out.println("Nasluchuje na porcie: " + port);
            System.out.println("Aby zatrzymac serwer nacisnij ctrl+c");
        }
        catch (Exception exception) {
            System.err.println("Serwer XML-RPC: " + exception);
        }
    }

}
