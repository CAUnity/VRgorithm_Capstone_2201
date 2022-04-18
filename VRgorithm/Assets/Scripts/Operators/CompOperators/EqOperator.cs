using UnityEngine;

public class EqOperator : ICompOperator {
    public int lhs { get; set; }
    public int rhs { get; set; }

    public bool instruction() {
        return lhs == rhs;
    }
}
