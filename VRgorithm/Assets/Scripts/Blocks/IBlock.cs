
using UnityEngine;

public interface IBlock {
    IBlock next { get; set; }
    IBlock prev { get; set; }

    bool instruction();
    
}
