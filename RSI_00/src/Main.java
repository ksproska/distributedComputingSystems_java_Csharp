import java.net.InetAddress;
import java.net.UnknownHostException;
import java.time.format.DateTimeFormatter;
import java.time.LocalDateTime;

class MyData {
    public static void info() {
        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("yyyy/MM/dd HH:mm:ss");
        LocalDateTime now = LocalDateTime.now();
        System.out.println(dtf.format(now));
        System.out.println("Kamila Sproska 254534");
        System.out.println(System.getProperty("user.name"));
        System.out.println(System.getProperty("os.name"));
        System.out.println(System.getProperty("java.version"));
        try {
            System.out.println(InetAddress.getLocalHost().getHostAddress());
        }
        catch (UnknownHostException e) {
        }
    }
}

//public class Main {
//    public static void main(String[] args) {
//        MyData.info();
//    }
//}
