using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VRInteract.Operands
{
    public class ArithOperandController : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown dropDown;
        public Action<IArithOperator> OnUpdate;
        private void Start()
        {
            dropDown.ClearOptions();
            dropDown.AddOptions(VrCompiler.Ins.ArithKeys);
            dropDown.onValueChanged.AddListener(OnValueChanged);
            OnValueChanged(dropDown.value);
        }
        private void OnValueChanged(int val)
        {
            OnUpdate(GetVariable(val));
        }
        private IArithOperator GetVariable(int val)
        {
            return VrCompiler.Ins.GetArithOperator(dropDown.options[val].text);
        }
    }
}