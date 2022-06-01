using System.Collections.Generic;
using System.Linq;
using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

namespace VRInteract
{
    public class BlockBuilder : MonoSingleton<BlockBuilder>
    {
        [SerializeField] private Transform tray;
        [SerializeField] private Transform environment;
        
        [Header("Prefabs")]
        [SerializeField] private GameObject arithBlock;
        [SerializeField] private GameObject ifBlock;
        [SerializeField] private GameObject whileBlock;
        public void SetPos(Vector3 worldPos)
        {
            transform.position = worldPos;
        }
        public void CreateArith()
        {
            BuildBlock(arithBlock);
        }
        public void CreateIf()
        {
            BuildBlock(ifBlock);
        }
        public void CreateWhile()
        {
            BuildBlock(whileBlock);
        }
        public void AddUserVariable()
        {
            var keys = VrCompiler.Ins.NotConstantVariableKeys;
            var last = (char)('A'+keys.Count); //create next alphabet
            VrCompiler.Ins.CreateIntVariable(last.ToString(), 0,VariableType.User);
        }
        public void RemoveUserVariable()
        {
            var keys = VrCompiler.Ins.UserVariableKeys;
            if (keys.Count > 0)
            {
                VrCompiler.Ins.DestroyIntVariable(keys.Last()); //destroy last key
            }
        }
        private void BuildBlock(GameObject go)
        {
            Instantiate(go,environment).transform.position = transform.position + Vector3.up;
        }
    }
}

