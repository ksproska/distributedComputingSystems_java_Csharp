package remoteObjects;

import java.io.Serializable;

public interface ITask<T> extends Serializable {
    T compute();
}
