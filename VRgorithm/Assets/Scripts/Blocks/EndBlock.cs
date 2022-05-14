
using UnityEngine;

public class EndBlock : MonoBehaviour, IBlock {
    public IBlock next { get; set; }
    public IBlock prev { get; set; }

    public IVariable ans;
    public IVariable user_ans;

    void Start() {
        
    }


    void Update() {
        
    }

    public bool instruction()
    {
        // compare answer
        return true;
    }
}
