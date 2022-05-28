﻿using System;
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
        [SerializeField] private EndBlock endBlock;
        [SerializeField] private IBlock processBlock;
        [Header("Variable")]
        [SerializeField] private GameObject variablePrefab;
        [SerializeField] private VariableTray variableTray;
        [SerializeField] private List<IntVariable> constVariables;
        [Header("Procedure")]
        [SerializeField] private Button startButton;
        [SerializeField] private Button nextButton;
        [SerializeField] private Button resetButton;
        [Header("Text")]
        [SerializeField] private GameObject rightText;
        [SerializeField] private GameObject wrongText;
        

        private readonly Dictionary<string,IntVariable> _variables = new Dictionary<string,IntVariable>();
        private readonly Dictionary<string,IArithOperator> _arithOperators = new Dictionary<string,IArithOperator>();
        private readonly Dictionary<string,ICompOperator> _compOperators = new Dictionary<string,ICompOperator>();
        
        public List<string> AllVariableKeys => _variables.Keys.ToList(); // get all variables, including const variables(0,1,2,...)
        public List<string> DefinedVariableKeys => _variables.Where(v=>v.Value.Type == VariableType.Defined)
            .Select(v=>v.Key)
            .ToList();//get
        public List<string> UserVariableKeys => _variables.Where(v=>v.Value.Type == VariableType.User)
            .Select(v=>v.Key)
            .ToList();//get
        public List<string> ConstantVariableKeys => _variables.Where(v=>v.Value.Type == VariableType.Const)
            .Select(v=>v.Key)
            .ToList();//get user variables only
        public List<string> NotConstantVariableKeys => _variables.Where(v=>v.Value.Type != VariableType.Const)
            .Select(v=>v.Key)
            .ToList();//get user variables only
        
        public List<string> ArithKeys => _arithOperators.Keys.ToList();
        public List<string> CompKeys => _compOperators.Keys.ToList();
        public event Action OnUpdateVariable = delegate {}; 

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
        public IntVariable CreateIntVariable(string id,int val,VariableType type)
        {
            var instance = Instantiate(variablePrefab).GetComponent<IntVariable>();
            instance.Type = type;
            instance.Name = id;
            instance.Value = val;
            _variables.Add(id,instance);
            
            if (type == VariableType.Const)// const variable은 렌더링 X
                instance.gameObject.SetActive(false); 
            else
                variableTray.AddVariable(instance);
            
            OnUpdateVariable();
            return instance;
        }

        public void DestroyIntVariable(string id)
        {
            if (!_variables.ContainsKey(id))
            {
                Debug.Log($"Failed to destroy variable [{id}]");
            }

            var instance = _variables[id];
            variableTray.RemoveVariable(instance);
            _variables.Remove(id);
            Destroy(instance.gameObject);
            OnUpdateVariable();
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

            for (var i = 0; i < 10; i++)//상수 만들기
            {
                CreateIntVariable(i.ToString(), i, VariableType.Const);
            }

            VrCompiler.Ins.CreateIntVariable("C", 0, VariableType.Defined);
            VrCompiler.Ins.CreateIntVariable("B", 5, VariableType.Defined);
            VrCompiler.Ins.CreateIntVariable("A", 3, VariableType.Defined);


            startButton.onClick.AddListener(StartRun);
            nextButton.onClick.AddListener(NextRun);
            resetButton.onClick.AddListener(ResetRun);
            processBlock = startBlock;

            TrainManager.Ins.teleport(startBlock.blockTransform.position);
        }

        private void StartRun()
        {
            if (processBlock == startBlock)
            {
                variableTray.SaveVariable();
            }
            while (processBlock != null) {
                print(processBlock);
                if(processBlock == endBlock)
                {
                    if(endBlock.instruction(_variables["C"].Value)){
                        // yes
                        wrongText.SetActive(false);
                        rightText.SetActive(true);
                    }
                    else {
                        // wrong
                        rightText.SetActive(false);
                        wrongText.SetActive(true);
                    }
                    break;
                }
                else
                {
                    processBlock.instruction();       
                    processBlock = processBlock.next;
                }
            }

            TrainManager.Ins.teleport(processBlock.blockTransform.position);
        }

        private void NextRun()
        {
            if (processBlock == startBlock)
            {
                variableTray.SaveVariable();
            }
            TrainManager.Ins.StartMoveRoutine(processBlock.blockTransform.position);
            print(processBlock);

            if(processBlock == endBlock)
            {
                if(endBlock.instruction(_variables["C"].Value)){
                    // yes
                    wrongText.SetActive(false);
                    rightText.SetActive(true);
                }
                else {
                    // wrong
                    rightText.SetActive(false);
                    wrongText.SetActive(true);
                }
            }
            else
            {
                processBlock.instruction();       
                processBlock = processBlock.next;
            }
        }

        private void ResetRun()
        {
            processBlock = startBlock;
            variableTray.RetrieveVariable();
            TrainManager.Ins.teleport(processBlock.blockTransform.position);
        }
    }
}