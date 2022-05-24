using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;
using UnityEngine.UI;
using VRInteract.Blocks;
using VRInteract.Operands;

namespace VRInteract
{
    public class VrCompiler : MonoSingleton<VrCompiler>
    {
        [Header("Blocks")]
        [SerializeField] private StartBlock startBlock;
        [SerializeField] private IBlock processBlock;
        [Header("Variable")]
        [SerializeField] private GameObject variablePrefab;
        [SerializeField] private VariableTray variableTray;
        [Header("Procedure")]
        [SerializeField] private Button startButton;
        [SerializeField] private Button nextButton;
        [SerializeField] private Button resetButton;
        
        
        private readonly Dictionary<string,IntVariable> _variables = new Dictionary<string,IntVariable>();
        private readonly Dictionary<string,IArithOperator> _arithOperators = new Dictionary<string,IArithOperator>();
        private readonly Dictionary<string,ICompOperator> _compOperators = new Dictionary<string,ICompOperator>();
        
        public List<string> VariableKeys => _variables.Keys.ToList();
        public List<string> ArithKeys => _arithOperators.Keys.ToList();
        public List<string> CompKeys => _compOperators.Keys.ToList();
        
        public IArithOperator GetArithOperator(string id)
        {
            return _arithOperators[id];
        }
        public ICompOperator GetCompOperator(string id)
        {
            return _compOperators[id];
        }
        public IntVariable GetVariable(string id)
        {
            return _variables[id];
        }

        public IntVariable CreateIntVariable(string id,int val)
        {
            var instance = Instantiate(variablePrefab).GetComponent<IntVariable>();
            instance.Name = id;
            instance.Value = val;
            variableTray.AddVariable(instance);
            _variables.Add(id,instance);
            return instance;
        }

        /// <summary>
        /// MonoSingleton 상속받을때는 Awake대신 OnAwake override해서 써야함!
        /// </summary>
        protected override void OnAwake()
        {
            _arithOperators.Add("+",new AddOperator());
            _arithOperators.Add("-",new SubOperator());
            _arithOperators.Add("*",new MulOperator());
            _arithOperators.Add("/",new DivOperator());
            _arithOperators.Add("%",new ModOperator());
            
            _compOperators.Add("==",new EqOperator());
            _compOperators.Add(">",new GreaterOperator());
            _compOperators.Add(">=",new GreaterEqOperator());
            _compOperators.Add("<=",new LessEqOperator());
            _compOperators.Add("<",new LessOperator());
            _compOperators.Add("!=",new NeqOperator());
            
            startButton.onClick.AddListener(StartRun);
            nextButton.onClick.AddListener(NextRun);
            resetButton.onClick.AddListener(ResetRun);
            processBlock = startBlock;
        }

        private void StartRun()
        {
            while (processBlock != null) {
                NextRun();
            }
        }

        private void NextRun()
        {
            if(processBlock == startBlock){
                variableTray.SaveVariable();
            }
            print(processBlock);
            processBlock.instruction();
            processBlock = processBlock.next;
        }

        private void ResetRun()
        {
            processBlock = startBlock;
            variableTray.RetrieveVariable();
        }


    }
}