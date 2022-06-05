using UnityEngine;

public class SubOperator : IArithOperator {
    public int lhs { get; set; }
    public int rhs { get; set; }
    public int ret { get; set; }

    public int instruction() {
        ret = lhs - rhs;
        return ret;
    }
}
