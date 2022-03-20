import org.apache.xmlrpc.AsyncCallback;
import java.net.URL;

/**
 *  zawierała metody wywoływane gdy na serwerze zakończy się przetwarzanie procedury wywoływanej asynchronicznie
 */
public class AC implements AsyncCallback {
    public static final String ANSI_RESET = "\u001B[0m";
    public static final String ANSI_PURPLE = "\u001B[35m";
    public static final String ANSI_CYAN = "\u001B[36m";
    @Override
    public void handleResult(Object o, URL url, String s) {
        System.out.printf("""
                %sASYNC result%s %s: %s%s%s
                """, ANSI_CYAN, ANSI_RESET, s, ANSI_PURPLE, o, ANSI_RESET);
//        System.out.printf("""
//                %sASYNC Result%s:
//                \tObject result = %s%s%s;
//                \tMethod method = %s;
//                \tString URL    = %s;
//                """, ANSI_CYAN, ANSI_RESET, ANSI_PURPLE, o, ANSI_RESET, s, url);
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
