import org.apache.xmlrpc.WebServer;

public class SerwerRPC {
    public Integer echo(int x, int y) {
        return x + y;
    }
    public static void main(String[] args) {
        try {
            System.out.println("Startuje serwer XML-RPC...");
            // TODO: xxx -> 10000 + numer komputera w laboratorium
            int port = 10000;
            WebServer server = new WebServer(port);
            server.addHandler("MojSerwer", new SerwerRPC());
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
