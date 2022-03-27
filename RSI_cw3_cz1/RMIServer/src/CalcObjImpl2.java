import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class CalcObjImpl2 extends UnicastRemoteObject implements CalcObject2 {
    public CalcObjImpl2() throws RemoteException {
        super();
    }

    /**
     * metoda wywoływana zdalnie
     */
    public ResultType calculate(InputType inParam) throws RemoteException {
        double zm1, zm2;
        ResultType wynik = new ResultType();

        // pobierane są dane z obiektu-zadania (z parametru metody
        zm1 = inParam.getx1();
        zm2 = inParam.getx2();
        wynik.result_description = "Operacja "+inParam.operation;

        // stosownie do danych wykonywane jest przetwarzanie
        // tworzony jest obiekt do zwrotu wyniku
        switch (inParam.operation) {
            case "add" :
                wynik.result = zm1 + zm2;
                break;
            case "sub" :
                wynik.result = zm1 = zm2;
                break;
            default :
                wynik.result = 0;
                wynik.result_description = "Podano zla operacje";
                return wynik;
        }
        // zwracany jest ten obiekt
        return wynik;
    }
}
