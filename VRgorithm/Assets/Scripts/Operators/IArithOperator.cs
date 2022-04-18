using UnityEngine;

public interface IArithOperator
{
    IVariable lhs { get; set; }
    IVariable rhs { get; set; }
    IntVariable lhs_idx { get; set; }
    IntVariable rhs_idx { get; set; }
    int ret { get; set; }

    int instruction();
}
