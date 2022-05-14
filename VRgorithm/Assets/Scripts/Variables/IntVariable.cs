
using System;
using TMPro;
using UnityEngine;

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

    private void Awake()
    {
        OnValueUpdate += UpdateValUI;
        OnNameUpdate += UpdateVarNameUI;
    }

    private void UpdateValUI(int val)
    {
        valUI.text = val.ToString();
    }
    
    private void UpdateVarNameUI(string text)
    {
        varNameUI.text = text;
    }
}
