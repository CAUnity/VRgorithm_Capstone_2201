using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour {
    public IBlock process;
    public IntVariable outputVariable;

    public void Start() {
        process = GameObject.Find("startBlock").GetComponent<StartBlock>();
        outputVariable = GameObject.Find("outputVariable").GetComponent<IntVariable>();
        while (process != null) {
            print(process);
            process.instruction();
            process = process.next;
        }

        print(outputVariable.Value);
    }

    public void Update() {

    }
}
