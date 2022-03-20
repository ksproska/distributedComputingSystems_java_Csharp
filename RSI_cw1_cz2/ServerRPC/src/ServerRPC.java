import org.apache.xmlrpc.WebServer;

import java.time.LocalDateTime;
import java.util.Arrays;

public class ServerRPC {
    private static final String SERVER_NAME = "ServerRPC";
    // TODO: 10000 -> 10000 + numer komputera w laboratorium
    private static final int PORT = 10000;

    /**
     * Serwer  zawiera  usługę/procedurę  show,  która  podaje  informacje  o  dostępnych
     * procedurach – wyświetla ich listę z opisem (nazwa procedury, parametry, krótki opis)
     */
    public String show() {
        return String.format("""
                ----------------------------------------------------------------------------------------------------------------------------------
                %s (port: %s) - available methods:
                1. max int int                          - returns maximum value
                2. charAt String int                    - returns char at index of given text
                3. setTimer int int                     - returns array of int for seconds selected with the brake (val1) repeated (val2)
                4. distance double double double double - distance from place1: latitude1, longitude1, to place2: latitude2, longitude2
                5. myPrimes int int                     - number of primes in (min, max), and max prime value in given range
                
                To run async method add flag: -a
                ----------------------------------------------------------------------------------------------------------------------------------
                """,
                SERVER_NAME,
                PORT);
    }

    public Integer max(int val1, int val2) {
        return Math.max(val1, val2);
    }

    public String charAt(String text, int charInx) {
        if(text.length() <= charInx) {
            // TODO: method cannot return null values
            return null;
        }
        return text.charAt(charInx) + "";
    }

    public Integer[] setTimer(int everyXSec, int repeat) {
//        System.out.println("Timer started...");
        Integer[] arrayInt = new Integer[repeat];
        try {
            for (int i = 0; i < repeat; i++) {
                Thread.sleep(1000L * everyXSec);
                arrayInt[i] = LocalDateTime.now().getSecond();
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
            Thread.currentThread().interrupt();
        }
//        System.out.println("... timer has finished.");
        return arrayInt;
    }

    private static Double toRad(Double value) {
        return value * Math.PI / 180;
    }

    /**
     * zwraca odległość między dwoma punktami na powierzchni Ziemi.
     * Parametry tej metody to współrzędne geograficzne obu punktów
     */
    public Double distance(double latitude1, double longitude1, double latitude2, double longitude2) {
        final int R = 6371;
        double latDistance = toRad(latitude2-latitude1);
        double lonDistance = toRad(longitude2-longitude1);
        double a = Math.sin(latDistance / 2) * Math.sin(latDistance / 2) +
                Math.cos(toRad(latitude1)) * Math.cos(toRad(latitude2)) *
                        Math.sin(lonDistance / 2) * Math.sin(lonDistance / 2);
        double c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));
        return R * c;
    }

    /**
     * zwraca ilość liczb pierwszych w podanym przedziale [min, max]
     * oraz największą liczbę pierwszą mniejszą/równą max.
     * Sprawdzić/przetestować dla dużych wartości, np. min= 100000000 max=11000000
     */
    public Integer[] myPrimes(int min, int max) {
        int counter = 0;
        int lastPrime = 0;
        if(min > max) {
            return null;
        }
        for(int i = min; i <= max; i++){
            if(isPrime(i)){
                counter++;
                lastPrime = i;
            }
        }
        return new Integer[] {counter, lastPrime};
    }

    public static boolean isPrime(int number) {
        for(int i = 2; i <= number/i; ++i){
            if(number % i == 0) {
                return false;
            }
        }
        return true;
    }

    //------------------------------------------------------------------------------------------------------------------

    public static void startServer() {
        WebServer server = new WebServer(PORT);
        server.addHandler(SERVER_NAME, new ServerRPC());
        server.start();
    }

    public static void main(String[] args) {
        try {
            System.out.println("""
                    ________________________________
                    Server XML-RPC is starting...
                    """);
            startServer();
            System.out.printf("""
                    Server has started successfully.
                    NAME:      %s
                    PORT:      %s
                    to finish: ctrl+c
                    ________________________________
                    """, SERVER_NAME, PORT);
        }
        catch (Exception exception) {
            System.err.printf("Server XML-RPC (NAME: %s; PORT: %s): %s\n", SERVER_NAME, PORT, exception);
        }
    }
}
