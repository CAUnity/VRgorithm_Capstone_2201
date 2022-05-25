
using System.Collections.Generic;
using UnityEngine;

public interface IBlock {
    IBlock next { get; set; }
    List<IBlock> prev { get; set; }
    Transform blockTransform { get; }

    bool instruction();
}
