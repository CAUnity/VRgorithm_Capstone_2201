using UnityEngine;

public class ArrayVariable : MonoBehaviour, IVariable, IIndexer {
    public int Size { get; set; }
    public IntVariable[] Value = new IntVariable[10];

    public string Name {
        get { return Name; }
        set { Name = value; }
    }

    public IntVariable this[int index] {
        get { return this.Value[index]; }
        set { Value[index] = value; }
    }
}
