import org.apache.xmlrpc.WebServer;

public class SerwerRPC {

    /**
     * zwracała sumę dwóch zmiennych całkowitych podanych jako parametry wywołania metody
     */
    public Integer echo(int x, int y) {
        return x + y;
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

    public static void main(String[] args) {
        try {
            System.out.println("Startuje serwer XML-RPC...");
            // TODO: xxx -> 10000 + numer komputera w laboratorium
            int port = 10000;
            WebServer server = new WebServer(port);
            //ponizej tworzy się obiekt swojej klasy serwera i uruchomia się go:
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

// KAMILA STACJONARNY: java -cp "F:\rozproszone_systemy\xmlrpc-1.2-b1.jar" "F:\rozproszone_systemy\RSI_cw1\src\SerwerRPC.java"
