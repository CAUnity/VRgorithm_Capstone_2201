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
            var tr = variable.transform;
            tr.SetParent(transform);
            tr.localPosition = (Vector3.right/5f) * _variables.Count;
        }


        public void SaveVariable()
        {
            savedValues.Clear();
            for(int i=0;i<_variables.Capacity;i++) {
                savedValues.Add(_variables[i].Value);
            }
        }

        public void RetrieveVariable()
        {
            for (int i=0;i < _variables.Capacity;i++) {
                _variables[i].Value = savedValues[i];
            }
        }



    }
}