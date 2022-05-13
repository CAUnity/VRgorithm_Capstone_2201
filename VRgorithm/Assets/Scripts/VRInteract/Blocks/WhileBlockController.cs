using UnityEngine;
using VRInteract.Operands;

namespace VRInteract.Blocks
{
    public class WhileBlockController : BlockController
    {
        [SerializeField] private InConnector inConnector;
        [SerializeField] private OutConnector trueConnector,falseConnector;
        [SerializeField] private WhileBlock whileBlock;
        [SerializeField] private VariableController leftVar, rightVar;
        [SerializeField] private CompOperandController operand;
        
        public override IBlock Block => whileBlock;
        
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
            whileBlock.prev.Add(connector.Block);
        }
        private void OnInDisconnected(OutConnector connector)
        {
            whileBlock.prev.Remove(connector.Block);
        }
        
        private void OnTrueConnected(InConnector connector)
        {
            whileBlock.trueBlock = connector.Block;
        }
        private void OnTrueDisconnected()
        {
            whileBlock.next = null;
        }
        
        private void OnFalseConnected(InConnector connector)
        {
            whileBlock.falseBlock = connector.Block;
        }
        private void OnFalseDisconnected()
        {
            whileBlock.next = null;
        }
        
        private void OnLeftVarUpdate(IntVariable variable)
        {
            whileBlock.lhs = variable;
        }
        private void OnRightVarUpdate(IntVariable variable)
        {
            whileBlock.rhs = variable;
        }
        private void OnOperandUpdate(ICompOperator comp)
        {
            whileBlock.comp = comp;
        }
    }
}