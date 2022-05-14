using UnityEngine;
using System.Collections.Generic;

public class ArrayVariable : MonoBehaviour, IVariable, IIndexer {
    public int Size { get; set; } = 5;
    public IntVariable[] Value;

    public string Name {
        get { return Name; }
        set { Name = value; }
    }

    public IntVariable this[int index] {
        get { return this.Value[index]; }
        set { Value[index] = value; }
    }

    public void Start(){
        Value = new IntVariable[Size];
        for(int i=0;i<Size;i++){
            Value[i] = new IntVariable();
        }
    }
}
