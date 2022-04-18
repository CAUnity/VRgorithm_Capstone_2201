using UnityEngine;

public interface IArithOperator {
    int lhs { get; set; }
    int rhs { get; set; }
    int ret { get; set; }

    int instruction();
}
