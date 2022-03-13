import org.apache.xmlrpc.AsyncCallback;

import java.net.URL;

public class AC implements AsyncCallback {
    @Override
    public void handleResult(Object o, URL url, String s) {
        System.out.printf("handleResult(Object: %s, URL: %s, String: %S)", o, url, s);
    }

    @Override
    public void handleError(Exception e, URL url, String s) {
        System.out.printf("handleError(Exception: %s, URL: %s, String: %S)", e, url, s);
    }
}
