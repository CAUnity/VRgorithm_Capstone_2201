using UnityEngine;
using System.Collections.Generic;
public class Tester : MonoBehaviour {
    ArrayVariable inputArray;
    IntVariable outputVariable;
    StartBlock startBlock;
    ArithBlock arithBlock_1;
    ArithBlock arithBlock_2;
    WhileBlock whileBlock;
    EndBlock endBlock;
    List<IVariable> var_list;

    public void Awake() {
        inputArray = GameObject.Find("inputArray").GetComponent<ArrayVariable>();
        inputArray[0] = new IntVariable();
        inputArray[0].Value = 10;
        inputArray[1] = new IntVariable();
        inputArray[1].Value = 20;
        inputArray[2] = new IntVariable();
        inputArray[2].Value = 30;

        inputArray[3] = new IntVariable();
        inputArray[3].Value = 200;

        startBlock = GameObject.Find("startBlock").GetComponent<StartBlock>();
        arithBlock_1 = GameObject.Find("arithBlock_1").GetComponent<ArithBlock>();
        arithBlock_2 = GameObject.Find("arithBlock_2").GetComponent<ArithBlock>();
        whileBlock = GameObject.Find("whileBlock").GetComponent<WhileBlock>();
        endBlock = GameObject.Find("endBlock").GetComponent<EndBlock>();
        outputVariable = GameObject.Find("outputVariable").GetComponent<IntVariable>();

        startBlock.next = arithBlock_1;
        arithBlock_1.next = whileBlock;
        whileBlock.trueBlock = arithBlock_2;
        whileBlock.falseBlock = endBlock;
        whileBlock.comp = new LessOperator();
        arithBlock_2.next = whileBlock; ;

        arithBlock_1.arith = new AddOperator();
        arithBlock_2.arith = new AddOperator();

        arithBlock_1.lhs = inputArray;
        arithBlock_1.lhs_idx = new IntVariable();
        arithBlock_1.lhs_idx.Value = 0;
        
        arithBlock_1.rhs = inputArray;
        arithBlock_1.rhs_idx = new IntVariable();
        arithBlock_1.rhs_idx.Value = 1;

        arithBlock_1.ret = outputVariable;


        whileBlock.lhs = outputVariable;
        whileBlock.rhs = inputArray;
        whileBlock.rhs_idx = new IntVariable();
        whileBlock.rhs_idx.Value = 3;


        arithBlock_2.lhs = inputArray;
        arithBlock_2.lhs_idx = new IntVariable();
        arithBlock_2.lhs_idx.Value = 2;

        arithBlock_2.rhs = outputVariable;

        arithBlock_2.ret = outputVariable;
    }

    public void Start() {
        
    }

    public void Update() {
        
    }
}
