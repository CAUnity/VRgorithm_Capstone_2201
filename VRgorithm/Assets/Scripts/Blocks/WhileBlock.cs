
using System.Collections.Generic;
using UnityEngine;

public class WhileBlock : MonoBehaviour, IBlock {
    public IBlock next { get; set; }
    public List<IBlock> prev { get; set; } = new List<IBlock>();
    public Transform blockTransform => transform;

    public IVariable lhs;
    public ICompOperator comp;
    public IVariable rhs;
    public IntVariable lhs_idx;
    public IntVariable rhs_idx;

    public IBlock trueBlock;
    public IBlock falseBlock;

    void Start() {
        
    }

    public bool instruction() {
        set_variable();

        if (comp.instruction()) {
            next = trueBlock;
        }
        else {
            next = falseBlock;
        }
        return true;
    }

    void set_variable(){
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
    }
}
