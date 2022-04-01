import java.rmi.Remote;

public interface IClient {
    public <T extends Remote> T getRemoteObject(String serviceAddress, Class<T> objectInterface);
}
