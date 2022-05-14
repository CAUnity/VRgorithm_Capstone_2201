using UnityEngine;

public interface ICompOperator {
    int lhs { get; set; }
    int rhs { get; set; }

    bool instruction();
}
