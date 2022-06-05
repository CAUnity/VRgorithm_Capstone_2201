using UnityEngine;

public class LessOperator : ICompOperator {
    public int lhs { get; set; }
    public int rhs { get; set; }

    public bool instruction() {
        return lhs < rhs;
    }
}
