import org.apache.xmlrpc.AsyncCallback;
import java.net.URL;

/**
 *  zawierała metody wywoływane gdy na serwerze zakończy się przetwarzanie procedury wywoływanej asynchronicznie
 */
public class AC implements AsyncCallback {
    @Override
    public void handleResult(Object o, URL url, String s) {
        System.out.printf("handleResult(Object: %s, URL: %s, String: %S\n)", o, url, s);
    }

    @Override
    public void handleError(Exception e, URL url, String s) {
        System.out.printf("handleError(Exception: %s, URL: %s, String: %S\n)", e, url, s);
    }
}
