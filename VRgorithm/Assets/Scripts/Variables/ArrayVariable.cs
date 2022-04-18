using UnityEngine;

public class ArrayVariable : MonoBehaviour, IVariable, IIndexer {
    public int Size { get; set; }
    public int[] Value = new int[10];

    public string Name {
        get { return Name; }
        set { Name = value; }
    }

    public int this[int index] {
        get { return Value[index]; }
        set { Value[index] = value; }
    }

    void Start() {
        
    }

    void Update() {
        
    }
}
