using System;
using Common;

namespace VRInteract
{
    public class TestManager : MonoSingleton<TestManager>
    {
        private void Start()
        {
            VrCompiler.Ins.CreateIntVariable("a", 1);
            VrCompiler.Ins.CreateIntVariable("b", 2);
            VrCompiler.Ins.CreateIntVariable("c", 3);
            VrCompiler.Ins.CreateIntVariable("d", 4);
        }
    }
}