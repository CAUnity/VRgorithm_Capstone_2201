using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

namespace VRInteract
{
    public class TestManager : MonoSingleton<TestManager>
    {
        [SerializeField] private ObjectiveUI objectiveUI;
        [SerializeField] private ResultPresenter presenter;
        [SerializeField] private ClearUI clearUI;
        
        public void SetObjective()
        {
            objectiveUI.SetObjective(ProblemData.name,ProblemData.decription);
        }
        public void SetInputData()
        {
            var inputs = ProblemData.inputs;
            for (var i = 0; i < inputs.Count; i++)
            {
                var varName = (char)('A' + i);
                VrCompiler.Ins.CreateIntVariable(varName.ToString(), Convert.ToInt32(inputs[i]), VariableType.Defined);
            }
        }
        public void TestResults(List<int> results)
        {
            var result = CompareResults(results, ProblemData.outputs);
            if (result)
            {
                RequestManager.OnStageEnd(true);
                presenter.PrintSuccess();
                clearUI.SetActive(true);
            }
            else
            {
                presenter.PrintWrongText();
            }
        }
        private bool CompareResults(List<int> results,ArrayList output)
        {
            for (var i = 0; i < output.Count; i++)
            {
                if (results[i] != (int)output[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}