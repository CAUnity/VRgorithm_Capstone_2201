
using System.Collections.Generic;
using UnityEngine;

public class EndBlock : MonoBehaviour, IBlock {
    public IBlock next { get; set; }
    public List<IBlock> prev { get; set; } = new List<IBlock>();
    public Transform blockTransform => transform;

    public IntVariable ans;
    
    public bool instruction(){
        return true;
    }
}
