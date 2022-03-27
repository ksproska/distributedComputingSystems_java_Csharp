import java.io.Serializable;

/**
 *  typ wyniku obliczeń zwracanego przez metodę zdalnego obiektu
 */
public class ResultType implements Serializable {
    private static final long serialVersionUID = 102L;
    String result_description;
    public double result;
}
