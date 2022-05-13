using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace VRInteract.Operands
{
    public class VariableController : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown dropDown;
        public Action<IntVariable> OnUpdate;
        
        private void Start()
        {
            dropDown.ClearOptions();
            dropDown.AddOptions(VrCompiler.Ins.VariableKeys);
            dropDown.onValueChanged.AddListener(OnValueChanged);
            OnValueChanged(dropDown.value);
        }
        private void OnValueChanged(int val)
        {
            OnUpdate(GetVariable(val));
        }
        private IntVariable GetVariable(int val)
        {
            return VrCompiler.Ins.GetVariable(dropDown.options[val].text);
        }
    }
}