import org.apache.xmlrpc.XmlRpcClient;
import java.util.Vector;

public class clientRPC {
    public static void main(String[] args) {
        try {
            XmlRpcClient srv = new XmlRpcClient("http://localhost:xxx");
            Vector<Integer> params = new Vector<Integer>();
            params.addElement(new Integer(13));
            params.addElement(new Integer(21));
            Object result = srv.execute("MojSerwer.echo", params);
            int wynik = ((Integer) result).intValue();
            System.out.println(wynik);
        } catch (Exception exception) {
            System.err.println("Klient XML-RPC: " +exception);
        }
    }
}
