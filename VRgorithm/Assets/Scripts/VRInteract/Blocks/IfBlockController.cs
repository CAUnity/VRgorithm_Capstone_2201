using UnityEngine;
using VRInteract.Operands;

namespace VRInteract.Blocks
{
    public class IfBlockController : BlockController
    {
        [SerializeField] private InConnector inConnector;

        [SerializeField] private OutConnector trueConnector,falseConnector;
        [SerializeField] private IfBlock ifBlock;
        [SerializeField] private VariableController leftVar, rightVar;
        [SerializeField] private CompOperandController operand;
        public override IBlock Block => ifBlock;
        
        private void Awake()
        {
            inConnector.OnConnect += OnInConnected;
            inConnector.OnDisConnect += OnInDisconnected;
            
            trueConnector.OnConnect += OnTrueConnected;
            trueConnector.OnDisConnect += OnTrueDisconnected;

            falseConnector.OnConnect += OnFalseConnected;
            falseConnector.OnDisConnect += OnFalseDisconnected;
            
            leftVar.OnUpdate += OnLeftVarUpdate;
            rightVar.OnUpdate += OnRightVarUpdate;
            operand.OnUpdate += OnOperandUpdate;
        }
        
        private void OnInConnected(OutConnector connector)
        {
            ifBlock.prev.Add(connector.Block);
        }
        private void OnInDisconnected(OutConnector connector)
        {
            ifBlock.prev.Remove(connector.Block);
        }
        
        private void OnTrueConnected(InConnector connector)
        {
            ifBlock.trueBlock = connector.Block;
        }
        private void OnTrueDisconnected()
        {
            ifBlock.trueBlock = null;
        }
        private void OnFalseConnected(InConnector connector)
        {
            ifBlock.falseBlock = connector.Block;
        }
        private void OnFalseDisconnected()
        {
            ifBlock.falseBlock = null;
        }
        
        private void OnLeftVarUpdate(IntVariable variable)
        {
            ifBlock.lhs = variable;
        }
        private void OnRightVarUpdate(IntVariable variable)
        {
            ifBlock.rhs = variable;
        }
        private void OnOperandUpdate(ICompOperator comp)
        {
            ifBlock.comp = comp;
        }
    }
}