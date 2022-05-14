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
            var tr = variable.transform;
            tr.SetParent(transform);
            tr.localPosition = (Vector3.right/5f) * _variables.Count;
        }
    }
}