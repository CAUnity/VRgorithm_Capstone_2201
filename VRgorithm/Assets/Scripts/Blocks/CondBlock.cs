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

    void Start() {
        
    }


    void Update() {
        
    }

    public bool instruction()
    {
        comp.lhs = lhs;
        comp.rhs = rhs;
        comp.lhs_idx = lhs_idx;
        comp.rhs_idx = rhs_idx;

        return comp.instruction();
    }
}
