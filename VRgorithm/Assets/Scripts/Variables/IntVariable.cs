
using System;
using TMPro;
using UnityEngine;

public enum VariableType
{
    Const,//상수, 0,1,2,3,4,5,6,7,8,9 ...
    Defined,//문제 조건으로 주어짐
    User//유저가 자유롭게 추가/제거 하는 Variable
}
public class IntVariable : MonoBehaviour, IVariable
{
    private int _value;
    public int Value
    {
        get => _value;
        set
        {
            _value = value;
            OnValueUpdate(_value);
        }
    }

    private string _varName;
    public string Name
    {
        get => _varName;
        set
        {
            _varName = value;
            OnNameUpdate(_varName);
        }
    }

    [SerializeField] private TextMeshProUGUI valUI;
    [SerializeField] private TextMeshProUGUI varNameUI;
    
    public event Action<int> OnValueUpdate = delegate {  };
    public event Action<string> OnNameUpdate = delegate {  };
    public VariableType Type { get; set; }

    private void Awake()
    {
        OnValueUpdate += UpdateValUI;
        OnNameUpdate += UpdateVarNameUI;
    }
    private void UpdateValUI(int val)
    {
        if(Type == VariableType.Const)
            return;
        valUI.text = val.ToString();
    }
    private void UpdateVarNameUI(string text)
    {
        if(Type == VariableType.Const)
            return;
        varNameUI.text = text;
    }
}
