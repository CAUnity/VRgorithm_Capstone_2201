using UnityEngine;

public class StartBlock : MonoBehaviour, IBlock {
    public IBlock next { get; set; }
    public IBlock prev { get; set; }

    void start() {
    }

    public bool instruction() {
        // read input to input ArrayVariable

        return true;
    }
}
