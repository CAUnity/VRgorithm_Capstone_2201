using UnityEngine;


public class IntVariable : MonoBehaviour, IVariable {
    public int Value { get; set; }

    public string Name {
        get { return Name; }
        set { Name = value; }
    }

    void start() {

    }
}
