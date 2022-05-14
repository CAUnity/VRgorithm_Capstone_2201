using System;
using TMPro;
using UnityEngine;

namespace VRInteract.Operands
{
    public class CompOperandController : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown dropDown;
        public Action<ICompOperator> OnUpdate;
        private void Start()
        {
            dropDown.ClearOptions();
            dropDown.AddOptions(VrCompiler.Ins.CompKeys);
            dropDown.onValueChanged.AddListener(OnValueChanged);
            OnValueChanged(dropDown.value);
        }
        private void OnValueChanged(int val)
        {
            OnUpdate(GetVariable(val));
        }
        private ICompOperator GetVariable(int val)
        {
            return VrCompiler.Ins.GetCompOperator(dropDown.options[val].text);
        }
    }
}