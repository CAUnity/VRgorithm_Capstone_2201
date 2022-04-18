using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondBlock : MonoBehaviour, IBlock {
    public IBlock next { get; set; }
    public IBlock prev { get; set; }

    public IVariable lhs;
    public ICompOperator comp;
    public IVariable rhs;
    public IntVariable lhs_idx;
    public IntVariable rhs_idx;

    public bool instruction()
    {
        if (lhs is IntVariable) {
            comp.lhs = ((IntVariable)lhs).Value;
        }
        else {
            comp.lhs = ((ArrayVariable)lhs).Value[lhs_idx.Value].Value;
        }

        if (rhs is IntVariable) {
            comp.rhs = ((IntVariable)rhs).Value;
        }
        else {
            comp.rhs = ((ArrayVariable)rhs).Value[rhs_idx.Value].Value;
        }

        return comp.instruction();
    }
}
