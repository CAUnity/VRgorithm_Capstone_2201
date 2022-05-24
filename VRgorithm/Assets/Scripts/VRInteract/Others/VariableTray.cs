using System.Collections.Generic;
using UnityEngine;

namespace VRInteract.Operands
{
    public class VariableTray : MonoBehaviour
    {
        private readonly List<IntVariable> _variables = new List<IntVariable>();
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
                _variables[i].transform.localPosition= Vector3.right / 5f * i;
            }
        }
    }
}