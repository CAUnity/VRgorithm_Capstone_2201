using System.Collections.Generic;
using UnityEngine;

public class StartBlock : MonoBehaviour, IBlock {
    public IBlock next { get; set; }
    public List<IBlock> prev { get; set; } = new List<IBlock>();
    public Transform blockTransform => transform;
    void start() {
    }

    public bool instruction() {
        // read input to input ArrayVariable

        return true;
    }
}
