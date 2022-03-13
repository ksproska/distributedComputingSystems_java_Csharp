import org.apache.xmlrpc.XmlRpcClient;
import java.util.Vector;

public class ClientRPC {
    public static void main(String[] args) {
        try {
            // kod utworzenia obiektu wywołania metody serwera,
            // TODO: 10000 -> 10000 + numer komputera w laboratorium
            XmlRpcClient srv = new XmlRpcClient("http://localhost:10000");

            AC cb = new AC();
            Vector<Integer> params2 = new Vector<>();
            params2.addElement(3000);
            srv.executeAsync("MojSerwer.execAsy", params2, cb);
            System.out.println("Wywolano asynchronicznie");

            // upakowania parametrów dla wywołania metody echo,
            Vector<Integer> params = new Vector<>();
            params.addElement(13);
            params.addElement(21);

            // wywołania samej metody,
            Object result = srv.execute("MojSerwer.echo", params);

            //Dodaj także wyświetlanie otrzymanej wartość.
            int wynik = ((Integer) result).intValue();
            System.out.println(wynik);
        }
        catch (Exception exception) {
            System.err.println("Klient XML-RPC: " +exception);
        }
    }
}
