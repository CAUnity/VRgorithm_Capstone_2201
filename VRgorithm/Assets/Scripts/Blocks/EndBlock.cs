
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
        if(ans == user_ans) // == comp �Լ� ��������
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
