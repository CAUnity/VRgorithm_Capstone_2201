using System;
using Common;

namespace VRInteract
{
    public class TestManager : MonoSingleton<TestManager>
    {
        private void Start()
        {
            VrCompiler.Ins.CreateIntVariable("a", 1,VariableType.Defined);
            VrCompiler.Ins.CreateIntVariable("b", 2,VariableType.Defined);
            VrCompiler.Ins.CreateIntVariable("c", 3,VariableType.Defined);
        }
    }
}