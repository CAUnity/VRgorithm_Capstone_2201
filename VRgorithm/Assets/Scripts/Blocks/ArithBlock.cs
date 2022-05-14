using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArithBlock : MonoBehaviour, IBlock {
    public IBlock next { get; set; }
    public List<IBlock> prev { get; set; } = new List<IBlock>();

    public IVariable lhs;
    public IArithOperator arith;
    public IVariable rhs;
    public IntVariable lhs_idx;
    public IntVariable rhs_idx;

    public IVariable ret;
    public IntVariable ret_idx;
    
    public bool instruction() {
        if(lhs is IntVariable) {
            arith.lhs = ((IntVariable)lhs).Value;
        }
        else {
            arith.lhs = ((ArrayVariable)lhs).Value[lhs_idx.Value].Value;
        }

        if (rhs is IntVariable) {
            arith.rhs = ((IntVariable)rhs).Value;
        }
        else {
            arith.rhs = ((ArrayVariable)rhs).Value[rhs_idx.Value].Value;
        }

        if (ret is IntVariable) {
            ((IntVariable)ret).Value = arith.instruction();
        }
        else {
            ((ArrayVariable)ret).Value[ret_idx.Value].Value = arith.instruction();
        }
        return true;
    }
}
