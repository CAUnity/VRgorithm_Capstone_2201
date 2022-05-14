using UnityEngine;
using System.Collections.Generic;

public class IntVariable : MonoBehaviour, IVariable {
    public Stack<int> stack;

    public int Value { get; set;} = 0;

    public string Name {
        get { return Name; }
        set { Name = value; }
    }

    void Start() {
        stack = new Stack<int>();
        stack.Push(Value);
    }

    public void undo() {
        stack.Pop();
        Value = stack.Peek();
    }
}
