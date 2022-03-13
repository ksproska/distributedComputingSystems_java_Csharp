import org.apache.xmlrpc.XmlRpcClient;
import java.util.Vector;

public class ClientRPC {
    public static void main(String[] args) {
        try {
            // TODO: xxx -> 10000 + numer komputera w laboratorium

            // kod utworzenia obiektu wywołania metody serwera,
            XmlRpcClient srv = new XmlRpcClient("http://localhost:xxx");

//            AC cb = new AC();
//            Vector<Integer> params2 = new Vector<Integer>();
//            params2.addElement(new Integer(3000));
//            srv.executeAsync("MojSerwer.execAsy", params2, cb);
//            System.out.println("Wywolano asynchronicznie");

            // upakowania parametrów dla wywołania metody echo,
            Vector<Integer> params = new Vector<Integer>();
            params.addElement(new Integer(13));
            params.addElement(new Integer(21));

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
