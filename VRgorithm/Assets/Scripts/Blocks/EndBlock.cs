
using System.Collections.Generic;
using UnityEngine;

public class EndBlock : MonoBehaviour, IBlock {
    public IBlock next { get; set; }
    public List<IBlock> prev { get; set; } = new List<IBlock>();
    public Transform blockTransform => transform;

    public IntVariable ans;
    public IVariable user_ans;

    void Start() {
        ans = new IntVariable();
        ans.Value = 16;
    }

    void Update() {
        
    }

    public bool instruction(){
        return true;
    }
  
    public bool instruction(int user_ans)
    {
        if(user_ans == ans.Value){
            return true;
        }
        else{
            return false;
        }
    }
}
