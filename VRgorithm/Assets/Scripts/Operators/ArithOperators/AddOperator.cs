using UnityEngine;

public class AddOperator : IArithOperator {
    public int lhs { get; set; }
    public int rhs { get; set; }
    public int ret { get; set; }
    
    public int instruction() {
        ret = lhs + rhs;
        return ret;
    }
}
