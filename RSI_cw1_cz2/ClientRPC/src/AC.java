import org.apache.xmlrpc.AsyncCallback;
import java.net.URL;

/**
 *  zawierała metody wywoływane gdy na serwerze zakończy się przetwarzanie procedury wywoływanej asynchronicznie
 */
public class AC implements AsyncCallback {
    @Override
    public void handleResult(Object o, URL url, String s) {
        System.out.printf("""
                Result:
                \tObject result = %s;
                \tMethod method = %s;
                \tString URL    = %s;
                """, o, s, url);
    }

    @Override
    public void handleError(Exception e, URL url, String s) {
        System.out.printf("""
                Exception:
                \tException error = %s;
                \tMethod method   = %s;
                \tString URL      = %s;
                """, e, url, s);
    }
}
