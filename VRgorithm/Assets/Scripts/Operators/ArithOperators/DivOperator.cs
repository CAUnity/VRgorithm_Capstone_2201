using UnityEngine;

public class DivOperator : IArithOperator {
    public int lhs { get; set; }
    public int rhs { get; set; }
    public int ret { get; set; }

    public int instruction() {
        // try catch
        ret = lhs / rhs;
        return ret;
    }
}
