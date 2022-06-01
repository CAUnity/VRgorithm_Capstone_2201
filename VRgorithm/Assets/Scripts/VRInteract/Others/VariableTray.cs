using System.Collections.Generic;
using UnityEngine;

namespace VRInteract.Operands
{
    public class VariableTray : MonoBehaviour
    {
        private readonly List<IntVariable> _variables = new List<IntVariable>();
        private readonly List<int> savedValues = new List<int>();


        public void AddVariable(IntVariable variable)
        {
            _variables.Add(variable);
            variable.transform.SetParent(transform);
            OrderVariables();
        }

        public void RemoveVariable(IntVariable variable)
        {
            _variables.Remove(variable);
            OrderVariables();
        }
        
        private void OrderVariables()
        {
            for (var i = 0; i < _variables.Count; i++)
            {
                _variables[i].transform.localPosition= Vector3.left / 10f * i;
            }
        }
        public void SaveVariable()
        {
            savedValues.Clear();
            for(int i=0;i<_variables.Count;i++) {
                savedValues.Add(_variables[i].Value);
            }
        }
        public void RetrieveVariable()
        {
            for (int i=0;i < _variables.Count;i++) {
                _variables[i].Value = savedValues[i];
            }
        }
    }
}