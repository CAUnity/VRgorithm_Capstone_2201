using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArithBlock : MonoBehaviour, IBlock {

    public IBlock next { get; set; }
    public IBlock prev { get; set; }

    public IVariable lhs;
    public IArithOperator arith;
    public IVariable rhs;
    public IntVariable lhs_idx;
    public IntVariable rhs_idx;

    public IVariable ret;
    public IntVariable ret_idx;
    
    void Start() {
        
    }

  
    void Update() {
        
    }

    public bool instruction()
    {
        arith.lhs = lhs;
        arith.rhs = rhs;
        arith.lhs_idx = lhs_idx;
        arith.rhs_idx = rhs_idx;

        // ret type에 따라서 조정 필요
        ret.Value.set(arith.instruction());
        return true;
    }
}
