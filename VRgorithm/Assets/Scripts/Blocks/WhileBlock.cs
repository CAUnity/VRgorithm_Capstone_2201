
using UnityEngine;

public class WhileBlock : MonoBehaviour, IBlock {
    public IBlock next { get; set; }
    public IBlock prev { get; set; }

    public CondBlock cond;
    public IBlock trueBlock;
    public IBlock falseBlock;

    void Start()
    {

    }

    void Update()
    {

    }

    public bool instruction()
    {
        if (cond.instruction())
        {
            next = trueBlock;
        }
        else
        {
            next = falseBlock;
        }

        return true;
    }

}
