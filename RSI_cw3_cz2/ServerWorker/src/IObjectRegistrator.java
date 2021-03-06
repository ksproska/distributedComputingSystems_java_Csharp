import remoteObjects.ARemoteObject;
import java.rmi.Remote;


public interface IObjectRegistrator extends Remote {
    <T extends ARemoteObject> void registerObject(String serviceAddress, Class<T> objectClass);
}
