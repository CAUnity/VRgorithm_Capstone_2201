using System;
using TMPro;
using UnityEngine;

namespace VRInteract.Operands
{
    public class AssignVariableController : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown dropDown;
        public Action<IntVariable> OnUpdate;
        
        private void Start()
        {
            VrCompiler.Ins.OnUpdateVariable += UpdateOptions;
            dropDown.onValueChanged.AddListener(OnValueChanged);
            UpdateOptions();
            OnValueChanged(dropDown.value);
        }
        private void UpdateOptions()
        {
            var curr = dropDown.options[dropDown.value].text;
            dropDown.ClearOptions();
            dropDown.AddOptions(VrCompiler.Ins.DefinedVariableKeys);
            dropDown.AddOptions(VrCompiler.Ins.UserVariableKeys);
            var index = dropDown.options.FindIndex(v=>v.text == curr);
            dropDown.value = index == -1 ? 0 : index;
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