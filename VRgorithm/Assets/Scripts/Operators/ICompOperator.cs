using UnityEngine;

public interface ICompOperator 
{
    IVariable lhs { get; set; }
    IVariable rhs { get; set; }
    IntVariable lhs_idx { get; set; }
    IntVariable rhs_idx { get; set; }

    bool instruction();

}
